using System.Collections.Generic;
using System.Net;

namespace Fluid.Core
{
    /// <summary>
    /// Allows sending packets to other clients
    /// From NiclasOlofsson
    /// </summary>
    public static class PacketSender
    {
        public static void SendData(byte[] data, IPEndPoint targetEndPoint) { }
        public static async void SendDataAsync(byte[] data, IPEndPoint targetEndPoint) { }
        public static async void SendDataAsync(byte[] data, int length, IPEndPoint targetEndPoint) { }
        public static async void SendPacketAsync(ClientConnection connection, IPacket packet) { }
        public static async void SendPacketAsync(ClientConnection connection, List<IPacket> packets) { }
        public static void CloseConnection(ClientConnection connection) { }
    }
}