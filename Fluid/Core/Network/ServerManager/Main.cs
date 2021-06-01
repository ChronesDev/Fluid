using Fluid.Core.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;

namespace Fluid.Core
{
    public class Main
    {
        public delegate void PacketHandler(RemoteClient client, Main server, IPacket packet);

        #region Constructors

        public Main()
        {
            PacketHandlers = new Dictionary<Type, PacketHandler>();
            ServerLogger.Info("Started");
            Core.PacketHandlers.RegisterHandlers(this);
            NetworkLock = new object();
            Clients = new List<RemoteClient>();
            LastTimeUpdate = DateTime.MinValue;
            NextChunkUpdate = DateTime.MinValue;
        }

        #endregion

        #region Properties

        public List<RemoteClient> Clients { get; set; }
        public TcpListener Listener { get; set; }
        public DateTime StartTime { get; private set; }

        protected internal RSACryptoServiceProvider CryptoServiceProvider { get; set; }
        protected internal RSAParameters ServerKey { get; set; }
        protected internal object NetworkLock { get; set; }

        protected Thread NetworkThread { get; set; }
        protected Dictionary<Type, PacketHandler> PacketHandlers { get; set; }

        private DateTime NextPlayerUpdate { get; set; }
        private DateTime NextChunkUpdate { get; set; }
        private DateTime LastTimeUpdate { get; set; }
        private DateTime NextScheduledSave { get; set; }

        private const int _millisecondsBetweenPhysicsUpdates = 250;

        #endregion

        #region Public methods

        public void RegisterPacketHandler(Type packetType, PacketHandler handler)
        {
            if (!typeof(IPacket).IsAssignableFrom(packetType))
                throw new ArgumentException("Packet type must derive from Craft.Net.Networking.IPacket");
            PacketHandlers[packetType] = handler;
        }

        public void Start(IPEndPoint endPoint)
        {
            if (30 != -1)
                NextScheduledSave = DateTime.Now.AddSeconds(30);

            CryptoServiceProvider = new RSACryptoServiceProvider(1024);
            ServerKey = CryptoServiceProvider.ExportParameters(true);

            StartTime = DateTime.Now;

            Listener = new TcpListener(endPoint);
            Listener.Start();
            Listener.BeginAcceptTcpClient(AcceptClientAsync, null);

            NetworkThread = new Thread(NetworkWorker);
            NetworkThread.Start();
        }

        public void Stop()
        {
            lock (NetworkLock)
            {
                if (Listener != null)
                {
                    Listener.Stop();
                    Listener = null;
                }
                if (NetworkThread != null)
                {
                    NetworkThread.Abort();
                    NetworkThread = null;
                }
            }
        }

        public RemoteClient GetClient(string name)
        {
            return Clients.SingleOrDefault(c => c.Username == name);
        }

        public void DisconnectPlayer(RemoteClient client, string reason = null)
        {
            if (!Clients.Contains(client))
                throw new InvalidOperationException("The server is not aware of this client.");
            lock (NetworkLock)
            {
                if (reason != null)
                {
                    try
                    {
                        if (client.NetworkClient != null && client.NetworkClient.Connected)
                        {
                            if (client.NetworkManager.NetworkMode == NetworkMode.Login)
                                client.NetworkManager.WritePacket(new LoginDisconnectPacket("\"" + reason + "\""), PacketDirection.Clientbound);
                            else
                                client.NetworkManager.WritePacket(new DisconnectPacket("\"" + reason + "\""), PacketDirection.Clientbound);
                        }
                    }
                    catch { }
                }
                try
                {
                    if (client.NetworkClient != null && client.NetworkClient.Connected)
                    {
                        client.NetworkClient.Close();
                    }
                }
                catch { }
                Clients.Remove(client);
                if (client.IsLoggedIn)
                {
                    var args = new PlayerLogInEventArgs(client);
                    OnPlayerLoggedOut(args);
                }
            }
        }

        #endregion

        #region Protected methods

        protected void AcceptClientAsync(IAsyncResult result)
        {
            lock (NetworkLock)
            {
                if (Listener == null)
                    return; // Server shutting down
                var client = new RemoteClient(Listener.EndAcceptTcpClient(result));
                client.NetworkStream = client.NetworkClient.GetStream();
                client.NetworkManager = new NetworkManager(client.NetworkStream);
                Clients.Add(client);
                Listener.BeginAcceptTcpClient(AcceptClientAsync, null);
            }
        }

        protected internal void UpdatePlayerList()
        {
            if (Clients.Count != 0)
            {
                for (int i = 0; i < Clients.Count; i++)
                {
                    foreach (RemoteClient client in Clients)
                    {
                        if (client.IsLoggedIn)
                            Clients[i].SendPacket(new PlayerListItemPacket(client.Username, true, client.Ping));
                    }
                }
            }
        }

        #endregion

        #region Internal methods

        internal void LogInPlayer(RemoteClient client)
        {
            client.SendPacket(new LoginSuccessPacket(client.UUID, client.Username));

        }

        #endregion

        #region Private methods

        private void NetworkWorker()
        {
            while (true)
            {
                UpdateScheduledEvents();
                lock (NetworkLock)
                {
                    for (int i = 0; i < Clients.Count; i++)
                    {
                        var client = Clients[i];
                        bool disconnect = false;
                        while (client.PacketQueue.Count != 0)
                        {
                            IPacket nextPacket;
                            if (client.PacketQueue.TryDequeue(out nextPacket))
                            {
                                try
                                {
                                    client.NetworkManager.WritePacket(nextPacket, PacketDirection.Clientbound);
                                }
                                catch (System.IO.IOException)
                                {
                                    disconnect = true;
                                    continue;
                                }
                                if (nextPacket is DisconnectPacket // TODO: This could be cleaner
                                    || (nextPacket is StatusPingPacket && client.NetworkManager.NetworkMode == NetworkMode.Status))
                                {
                                    disconnect = true;
                                }
                            }
                        }
                        if (disconnect)
                        {
                            DisconnectPlayer(client);
                            i--;
                            continue;
                        }
                        // Read packets
                        var timeout = DateTime.Now.AddMilliseconds(10);
                        while (client.NetworkClient.Available != 0 && DateTime.Now < timeout)
                        {
                            try
                            {
                                var packet = client.NetworkManager.ReadPacket(PacketDirection.Serverbound);
                                if (packet is DisconnectPacket)
                                {
                                    DisconnectPlayer(client);
                                    i--;
                                    break;
                                }
                                HandlePacket(client, packet);
                            }
                            catch (SocketException)
                            {
                                DisconnectPlayer(client);
                                i--;
                                break;
                            }
//                            catch (Exception e)
//                            {
//                                DisconnectPlayer(client, e.Message);
//                                i--;
//                                break;
//                            }
                        }
                        if (client.IsLoggedIn)
                            DoClientUpdates(client);
                    }
                }
                if (LastTimeUpdate != DateTime.MinValue)
                {
                    if ((DateTime.Now - LastTimeUpdate).TotalMilliseconds >= 50)
                    {
                        LastTimeUpdate = DateTime.Now;
                    }
                }
                if (NextChunkUpdate < DateTime.Now)
                    NextChunkUpdate = DateTime.Now.AddSeconds(1);
                Thread.Sleep(10);
            }
        }

        private void HandlePacket(RemoteClient client, IPacket packet)
        {
            if (!PacketHandlers.ContainsKey(packet.GetType()))
                return;
                //throw new InvalidOperationException("No packet handler registered for 0x" + packet.Id.ToString("X2"));
            PacketHandlers[packet.GetType()](client, this, packet);
        }

        private void UpdateScheduledEvents()
        {
            if (DateTime.Now > NextPlayerUpdate)
            {
                UpdatePlayerList();
                NextPlayerUpdate = DateTime.Now.AddMinutes(1);
            }
        }

        private void DoClientUpdates(RemoteClient client)
        {
            // Update keep alive, chunks, etc
            if (client.LastKeepAliveSent.AddSeconds(20) < DateTime.Now)
            {
                client.SendPacket(new KeepAlivePacket(FluidMath.Random.Next()));
                client.LastKeepAliveSent = DateTime.Now;
                // TODO: Confirm keep alive
            }
        }

        #endregion

        #region Events

        public event EventHandler<ConnectionEstablishedEventArgs> ConnectionEstablished;
        protected internal virtual void OnConnectionEstablished(ConnectionEstablishedEventArgs e)
        {
            if (ConnectionEstablished != null) ConnectionEstablished(this, e);
        }

        public event EventHandler<PlayerLogInEventArgs> PlayerLoggedIn;
        protected internal virtual void OnPlayerLoggedIn(PlayerLogInEventArgs e)
        {
            if (PlayerLoggedIn != null) PlayerLoggedIn(this, e);
        }

        public event EventHandler<PlayerLogInEventArgs> PlayerLoggedOut;
        protected internal virtual void OnPlayerLoggedOut(PlayerLogInEventArgs e)
        {
            if (PlayerLoggedOut != null) PlayerLoggedOut(this, e);
        }

        #endregion
    }
}
