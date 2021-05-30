using System.Net;

namespace Fluid.Core
{
    /// <summary>
    /// Stores info about the client connection
    /// </summary>
    public class ClientConnection
    {
        public IPEndPoint IPAddress; 
        
        /// <summary>
        /// Closes the connection
        /// </summary>
        public void Close() { }
    }
}
