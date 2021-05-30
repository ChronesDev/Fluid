using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading;
using System.Timers;
using Fluid.Core;
using Microsoft.VisualBasic;
using EventArgs = Fluid.Core.EventArgs;

namespace Fluid
{
    class Program
    {
        static readonly PriotisedEvent ev = new();
        
        static void Main(string[] args)
        {
            Player player = new OnlinePlayer();
            player.Is<OnlinePlayer>();
        }
    }
}