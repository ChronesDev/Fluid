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
            Stopwatch s = new();
            
            for (int i = 0; i < 1; i++)
            {
                s.Start();
                for (int i2 = 0; i2 < 1; i2++)
                {
                    Chunk chunk = new();
                    
                    chunk.Blocks[0, 0, 0] = new ShinyTestBlock();
                    
                    for (int x = 0; x < 16; x++)
                    {
                        for (int y = 0; y < 256; y++)
                        {
                            for (int z = 0; z < 16; z++)
                            {
                                var block = chunk.Blocks[x, y, z];
                                
                                if (block is null) Console.WriteLine($"Block at {x},{y},{z} is null.");
                                //else if (block is Air) Console.WriteLine($"Block at {x},{y},{z} is Air.");
                                else if (block is ShinyTestBlock) Console.WriteLine($"Block at {x},{y},{z} is ShinyTestBlock.");
                            }
                        }
                    }
                }
                s.Stop();
                Console.WriteLine($"Elapsed time: {s.ElapsedMilliseconds}");
                s.Reset();
                Server.Start();
            }
            ev.Invoke(new());
        }
    }
}