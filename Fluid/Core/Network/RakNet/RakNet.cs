using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluid.Core.Network.RakNet
{
    public abstract class RakNet
    {
        public static string VERSION = "1.0";
        public static byte PROTOCOL = 6;

        public static byte[] PACKETS = new byte[]
        {
            (byte) 0x00, (byte) 0xff, (byte) 0xff, (byte) 0x00,
            (byte) 0xfe, (byte) 0xfe, (byte) 0xfe, (byte) 0xfe,
            (byte) 0xfd, (byte) 0xfd, (byte) 0xfd, (byte) 0xfd,
            (byte) 0x12, (byte) 0x34, (byte) 0x56, (byte) 0x78
        };

        public static byte PACKET_ENCAPSULATE = 0x01;

        public static byte PACKET_OPEN_SESSION = 0x02;

        public static  byte PACKET_CLOSE_SESSION = 0x03;

        public static byte PACKET_INVALID_SESSION = 0x04;

        public static byte PACKET_SEND_QUEUE = 0x05;

        public static byte PACKET_ACK_NOTIFICATION = 0x06;

        public static byte PACKET_SET_OPTION = 0x07;

        public static byte PACKET_RAW = 0x08;

        public static byte PACKET_BLOCK_ADDRESS = 0x09;

        public static byte PACKET_UNBLOCK_ADDRESS = 0x10;

        public static byte PACKET_SHUTDOWN = 0x7e;

        public static byte PACKET_EMERGENCY_SHUTDOWN = 0x7f;
    }
}
