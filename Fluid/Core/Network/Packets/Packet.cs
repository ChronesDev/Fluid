using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluid.Core.Network.Packets
{
    class Packet
    {
        private ReadOnlyMemory<byte> _buffer;

        protected MemoryStreamReader lol
        public Packet(ReadOnlyMemory<byte> buffer)
        {
            _buffer = buffer;
        }
    }
}
