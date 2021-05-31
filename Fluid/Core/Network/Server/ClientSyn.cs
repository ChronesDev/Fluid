using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Fluid.Core
{
    public class ClientSyn
    {
        public TcpClient NetworkClient { get; set; }

        public short Ping { get; internal set; }

        static byte[] AddressInBytes = { 0, 0, 0, 0 };

        IPAddress address = new IPAddress(AddressInBytes);

        public Stream NetworkStream { get; set; }

        public NetworkManager NetworkManager { get; set; }

        public ClientSyn(TcpClient client)
        {
            this.NetworkClient = client;
        }
    }
}
