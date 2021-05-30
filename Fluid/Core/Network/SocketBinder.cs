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
        int port;
        string ip;

        /// <summary>
        /// Starts hearing on ip and port
        /// </summary>
        public SocketBinder(string ip, int port)
        {
            this.port = port;
            this.ip = ip;
        }

        public bool PortIsValid()
        {
            if (port < 1 || port > 65536)
            {
                return false; ;
            }
            return true;
        }
    }
}
