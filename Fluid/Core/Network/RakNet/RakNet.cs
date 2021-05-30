using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluid.Core.Network.RakNet
{
    public abstract class RakNet
    {
        public const string Version = "1.0";
        public const byte Protocol = 6;

        public const byte PacketEncapsulate  = 0x01;
        public const byte PacketOpenSession = 0x02;
        public const byte PacketCloseSession = 0x03;
        public const byte PacketInvalidSession = 0x04;
        public const byte PacketSendQueue = 0x05;
        public const byte PacketAckNotification = 0x06;
        public const byte PacketSetOption = 0x07;
        public const byte PacketRaw = 0x08;
        public const byte PacketBlockAddress = 0x09;
        public const byte PacketUnblockAddress = 0x10;
        public const byte PacketShutdown = 0x7E;
        public const byte PacketEmergencyShutdown = 0x7F;
        
        public static readonly byte[] Packets = new byte[]
        {
            0x00, 0xFF, 0xFF, 0x00,
            0xFE, 0xFE, 0xFE, 0xFE,
            0xFD, 0xFD, 0xFD, 0xFD,
            0x12, 0x34, 0x56, 0x78
        };
    }
}
