using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fluid.Core.Network
{
    public class SocketBinder
    {
        /// <summary>
        /// Stores the IP Address
        /// </summary>
        public IPAddress IPAddress { get; private set; }
        
        /// <summary>
        /// Stores the Port
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Starts hearing on ip and port
        /// </summary>
        public SocketBinder(IPAddress ipAddress, int port)
        {
            this.IPAddress = ipAddress;
            this.Port = port;
        }
        
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
