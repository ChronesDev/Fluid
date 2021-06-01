using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Fluid.Core
{
    public class RemoteClient : INotifyPropertyChanged
    {
        public RemoteClient(TcpClient client)
        {
            NetworkClient = client;
            PacketQueue = new ConcurrentQueue<IPacket>();
            KnownEntities = new List<int>();
            Settings = new ClientSettings();
            MaxDigDistance = 6;
            Tags = new Dictionary<string, object>();
        }

        public NetworkManager NetworkManager { get; set; }
        public TcpClient NetworkClient { get; set; }
        public Stream NetworkStream { get; set; }
        public bool IsLoggedIn { get; internal set; }
        public ConcurrentQueue<IPacket> PacketQueue { get; set; }
        public ClientSettings Settings { get; set; }
        public bool EncryptionEnabled { get; protected internal set; }
        public string Hostname { get; internal set; }
        public short Ping { get; internal set; }
        public string Username { get; internal set; }

        public int MaxDigDistance { get; set; }
        public Dictionary<string, object> Tags { get; set; }
        public string UUID { get; internal set; }

        protected internal DateTime LastKeepAlive { get; set; }
        protected internal DateTime LastKeepAliveSent { get; set; }
        protected internal DateTime ExpectedMiningEnd { get; set; }
        protected internal int BlockBreakStageTime { get; set; }
        protected internal DateTime? BlockBreakStartTime { get; set; }
        protected internal byte[] VerificationToken { get; set; }
        protected internal List<short> PaintedSlots { get; set; }

        internal bool PauseChunkUpdates = false;

        internal List<int> KnownEntities { get; set; }
        internal string ServerId { get; set; }

        protected internal byte[] SharedKey { get; set; }

        public void SendPacket(IPacket packet)
        {
            PacketQueue.Enqueue(packet);
        }

        public void Disconnect(string reason)
        {
            if (NetworkManager.NetworkMode == NetworkMode.Login)
                SendPacket(new LoginDisconnectPacket(reason));
            else
                SendPacket(new DisconnectPacket(reason));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected internal virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
