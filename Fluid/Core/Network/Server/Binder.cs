using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fluid.Core.Network
{
    public class Binder
    {
        public Binder(IPEndPoint endPoint)
        {
            this.EndPoint = endPoint;
        }

        public void Start()
        {
            Listener = new TcpListener(EndPoint);
            Listener.Start();
            Listener.AcceptTcpClientAsync(AcceptClientAsync, null);

            NetworkThread = new Thread(NetworkWorker);
            this.NetworkThread.Start();
        }

        protected void AcceptClientAsync(IAsyncResult result)
        {
            lock (NetworkLock)
            {
                if (Listener == null)
                    return; // Server shutting down
                var client = new ClientSyn(Listener.EndAcceptTcpClient(result));
                client.NetworkStream = client.NetworkClient.GetStream();
                client.NetworkManager = new NetworkManager(client.NetworkStream);
                Clients.Add(client);
                Listener.BeginAcceptTcpClient(AcceptClientAsync, null);
            }
        }


        /// <summary>
        /// Accept incoming Packets
        /// </summary>
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
                        Level.Time += (long)((DateTime.Now - LastTimeUpdate).TotalMilliseconds / 50);
                        LastTimeUpdate = DateTime.Now;
                    }
                }
                if (NextChunkUpdate < DateTime.Now)
                    NextChunkUpdate = DateTime.Now.AddSeconds(1);
                Thread.Sleep(10);
            }
        }


        /// <summary>
        /// Listens on incoming TCP Connections
        /// </summary>
        public TcpListener Listener { get; set; }

        /// <summary>
        /// Stores the EndPoint
        /// </summary>
        public IPEndPoint EndPoint { get; set; }

        /// <summary>
        /// Stores the IP Address
        /// </summary>
        public IPAddress IPAddress { get; private set; }
        
        /// <summary>
        /// Stores the Port
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Defines the Thread the Server is listening on
        /// </summary>
        protected Thread NetworkThread { get; set; }
        
        /// <summary>
        /// Checks whether the port in valid 
        /// </summary>
        public bool PortIsValid()
        {
            if (Port is < 1 or > 65536)
            {
                return false; ;
            }
            return true;
        }
    }
}
