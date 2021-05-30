using System.Net;

namespace Fluid.Core
{
    /// <summary>
    /// Stores info about the client connection
    /// </summary>
    public class ClientConnection
    {
        /// <summary>
        /// Stores the IP of the client
        /// </summary>
        public IPEndPoint IPAddress { get; set; } 
        
        /// <summary>
        /// Closes the connection
        /// </summary>
        public void Close() { }
        
        /// <summary>
        /// Bans the IP address and the client can no longer join the server with this ip
        /// </summary>
        public void BanIP() { }
    }
}
