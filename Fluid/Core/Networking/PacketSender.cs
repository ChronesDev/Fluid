using System;
using System.IO;
using System.Net;

namespace Fluid.Core
{
    public partial class Network
    {
        /// <summary>
        /// Allows sending packets to other clients
        /// </summary>
        public class PacketSender
        {
            /// <summary>
            /// An event that is being invoked when a packet is being sent
            /// </summary>
            public Event<CancelableEventArgs> PacketSent { get; protected set; } = new();
            
            /// <summary>
            /// Sends the packet to the client
            /// </summary>
            public void SendPacket(SocketAddress receiverAddress, BinaryWriter packet)
            {
                packet.Write("Test");
            }

            /// <summary>
            /// Sends the bytes to the client
            /// </summary>
            /// <param name="bytes">The bytes that are being sent</param>
            public void SendBytes( /* ClientConnection clientConnection */ Span<byte> bytes) { }
            
            /// <summary>
            /// Sends the bytes to the client
            /// </summary>
            /// <param name="bytes">The bytes that are being sent</param>
            public void SendBytes( /* ClientConnection clientConnection */ byte[] bytes) { }
        }
    }
}