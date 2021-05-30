using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fluid.Core.Network
{
    public class SocketBinder
    {
        public IPEndPoint EndPoint { get; private set; }

        public SocketBinder(IPEndPoint endpoint)
        {
            EndPoint = endpoint;
        }

        /// <summary>
        /// Creates the Endpoint for the Server
        /// </summary>
        public bool CreateEndpoint()
        {
            IPAddress IPAddress = Dns.Resolve("0.0.0.0").AddressList[0];
            EndPoint = new IPEndPoint(IPAddress, 19132);
            if(EndPoint == null)
            {
                return false;
            }
            return true;
        }
    }
}
