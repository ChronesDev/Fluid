namespace Fluid.Core
{
    /// <summary>
    /// Represents a Minecraft chunk
    /// </summary>
    public class Chunk
    {
        /// <summary>
        /// Returns true if the chunk has been generated
        /// </summary>
        public virtual bool IsGenerated => false;
        
        /// <summary>
        /// Stores the level where the chunk is in
        /// WARNING: You should NEVER change this value on your own unless you know what you are doing
        /// </summary>
        public Level Level { get; protected set; }

        /// <summary>
        /// The X position of the chunk
        /// WARNING: You should NEVER change this value on your own unless you know what you are doing
        /// </summary>
        public long ChunkX { get; protected set; }
        
        /// <summary>
        /// The Y position of the chunk
        /// WARNING: You should NEVER change this value on your own unless you know what you are doing
        /// </summary>
        public long ChunkY { get; protected set; }
        
        /// <summary>
        /// Stores all the Blocks
        /// WARNING: You should NEVER change this value on your own unless you know what you are doing
        /// </summary>
        public Block?[,,] Blocks { get; set; } = new Block[16, 256, 16];

        /// <summary>
        /// Constructor
        /// </summary>
        public Chunk(Level level, long chunkX, long chunkY)
        {
            this.Level = level;
            (this.ChunkX, this.ChunkY) = (chunkX, chunkY);
        }

        /// <summary>
        /// Fills the chunk with null
        /// </summary>
        protected void ClearChunk()
        {
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    for (int z = 0; z < 16; z++)
                    {
                        // TODO: Add x, y, z to chunk pos
                        Blocks[x, y, z] = null;
                    }
                }
            }
        }
        
        /// <summary>
        /// Sets a block safely
        /// </summary>
        /// <param name="localX">The local X position of the block</param>
        /// <param name="localY">The local Y position of the block</param>
        /// <param name="localZ">The local Z position of the block</param>
        public void SetLocalBlock(Block block, long localX, long localY, long localZ)
        {
            if (block.Chunk != this) block.Chunk = this;
            Blocks[localX, localY, localZ]?.Destroy();
            Blocks[localX, localY, localZ] = block;
        }
        
        
    }
}