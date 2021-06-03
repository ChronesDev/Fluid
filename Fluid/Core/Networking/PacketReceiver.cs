using System;

namespace Fluid.Core
{
    public partial class Network
    {
        /// <summary>
        /// Handles all incoming packets
        /// </summary>
        public partial class PacketReceiver
        {
            /// <summary>
            /// An event that is being invoked before the incoming data is being processed
            /// </summary>
            public Event<PrePacketReceivedEventArgs> PrePacketReceived { get; protected set; } = new();
            
            /// <summary>
            /// Handles incoming packets
            /// </summary>
            public void ReceivePacket(/* IPacket packet */) { }
            
            /// <summary>
            /// Handles incoming bytes
            /// </summary>
            /// <param name="bytes">The received bytes</param>
            public void ReceiveBytes(Span<byte> bytes) { }
            
            /// <summary>
            /// Handles incoming bytes
            /// </summary>
            /// <param name="bytes">The received bytes</param>
            public void ReceiveBytes(byte[] bytes) { }
        }
    }
}