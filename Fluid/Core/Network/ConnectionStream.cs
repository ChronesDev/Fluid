using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluid.Core.Network
{
    public class ConnectionStream
    {
        public ConnectionStream()
        {
            StringEncoding = Encoding.UTF8;
        }

        public static Encoding StringEncoding;
    }
}
