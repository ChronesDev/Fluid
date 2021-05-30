using System;

namespace Fluid.Core
{
    public class Chunk
    {
        /// <summary>
        /// Stores all the Blocks
        /// </summary>
        public Block[,,] Blocks { get; set; } = new Block[16, 256, 16];

        public Chunk()
        {
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    for (int z = 0; z < 16; z++)
                    {
                        Blocks[x, y, z] = new Air();
                    }
                }
            }
        }
    }
}