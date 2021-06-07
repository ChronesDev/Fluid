using System.Net;

namespace Fluid.Core
{
    public class Main
    {
        public Main(string ip, int port)
        {
            //Creates an IpEndPoint.
            IPAddress ipAddress = Dns.GetHostEntry(ip).AddressList[0];
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, port);

            //Serializes the IPEndPoint.
            SocketAddress socketAddress = ipLocalEndPoint.Serialize();
        }
    }
}
