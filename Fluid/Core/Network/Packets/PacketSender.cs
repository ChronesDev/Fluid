using Fluid.Core.Network;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Fluid.Core
{
    /// <summary>
    /// Allows sending packets to other clients
    /// From NiclasOlofsson
    /// </summary>
    public interface PacketSender
    {
        public void SendData(byte[] data, IPEndPoint targetEndPoint);
        public Task SendDataAsync(byte[] data, IPEndPoint targetEndPoint);
        public Task SendDataAsync(byte[] data, int length, IPEndPoint targetEndPoint);
        public Task SendPacketAsync(Session session, Packet message);
        public Task SendPacketAsync(Session session, List<Packet> message);
        void Close(Session session);
    }
}