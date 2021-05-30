using System;

namespace Fluid.Core
{
    /// <summary>
    /// Represents a Minecraft chunk
    /// </summary>
    public class Chunk
    {
        /// <summary>
        /// Stores the level where the chunk is in
        /// </summary>
        public Level Level { get; protected set; }

        /// <summary>
        /// The X position of the chunk
        /// </summary>
        public long ChunkX { get; protected set; }
        
        /// <summary>
        /// The Y position of the chunk
        /// </summary>
        public long ChunkY { get; protected set; }
        
        /// <summary>
        /// Stores all the Blocks
        /// </summary>
        public Block[,,] Blocks { get; set; } = new Block[16, 256, 16];

        /// <summary>
        /// Constructor
        /// </summary>
        public Chunk(Level level, long chunkX, long chunkY)
        {
            this.Level = level;
            (this.ChunkX, this.ChunkY) = (chunkX, chunkY);
            ClearChunk();
        }

        /// <summary>
        /// Fills the chunk with air
        /// </summary>
        protected void ClearChunk()
        {
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    for (int z = 0; z < 16; z++)
                    {
                        
                    }
                }
            }
        }

        public void SetLocalBlock(long localX, long localY, long localZ)
        {
            
        }
    }
}