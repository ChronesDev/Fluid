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

            this.NetworkThread.Start();
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
