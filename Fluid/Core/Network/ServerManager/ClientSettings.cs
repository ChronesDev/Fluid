using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Fluid.Core
{
    public class ClientSettings
    {
        public ClientSettings()
        {
            ColorsEnabled = true;
            MaxViewDistance = 10;
            ViewDistance = 3;
        }

        public bool ColorsEnabled { get; set; }
        public int MaxViewDistance { get; set; }
        public int ViewDistance { get; set; }
        public CultureInfo Locale { get; set; }
        public byte WalkingSpeed { get; set; }
        public byte FlyingSpeed { get; set; }
        public bool ShowCape { get; set; }
    }
}
