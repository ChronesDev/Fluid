using Fluid.Core.Logger;
using Fluid.Core.Network.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Fluid.Core
{
    public class Main
    {
        

        private DataPack[] PacketPool { get; set; }

        public void RegisterPacket(byte id, DataPack pack)
        {
            PacketPool[id & 0xff] = pack;
        }

        public void RegisterPackets()
        {
            PacketPool = new DataPack[256];
            RegisterPacket(ProtocolInfo.LOGIN_PACKET, new DataPack());
            RegisterPacket(ProtocolInfo.PLAY_STATUS_PACKET, new DataPack());
            RegisterPacket(ProtocolInfo.SERVER_TO_CLIENT_HANDSHAKE_PACKET, new DataPack());
            RegisterPacket(ProtocolInfo.CLIENT_TO_SERVER_HANDSHAKE_PACKET, new DataPack());
        }
    }
}
