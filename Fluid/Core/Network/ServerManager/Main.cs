using Fluid.Core.Logger;
using Fluid.Core.Network.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

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
