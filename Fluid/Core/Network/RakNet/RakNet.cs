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

        public static byte[] BYTES = new byte[]
        {
            (byte) 0x00, (byte) 0xff, (byte) 0xff, (byte) 0x00,
            (byte) 0xfe, (byte) 0xfe, (byte) 0xfe, (byte) 0xfe,
            (byte) 0xfd, (byte) 0xfd, (byte) 0xfd, (byte) 0xfd,
            (byte) 0x12, (byte) 0x34, (byte) 0x56, (byte) 0x78
        };

        public static byte PACKET_ENCAPSULATED = 0x01;
    }
}
