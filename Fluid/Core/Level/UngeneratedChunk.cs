namespace Fluid.Core
{
    /// <summary>
    /// Represents a Minecraft Chunk that hasn't been generated yet
    /// </summary>
    public class UngeneratedChunk : Chunk
    {
        /// <summary>
        /// Returns a new Ungenerated Chunk
        /// </summary>
        /// <param name="level"></param>
        /// <param name="chunkX"></param>
        /// <param name="chunkY"></param>
        /// <returns></returns>
        public static UngeneratedChunk New(Level level, long chunkX, long chunkY) => new UngeneratedChunk(level, chunkX, chunkY);

        /// <summary>
        /// Constructor of UngeneratedChunk
        /// </summary>
        /// <param name="level">The level where the chunk is in</param>
        /// <param name="chunkX">The X position of the chunk</param>
        /// <param name="chunkY">The Y position of the chunk</param>
        public UngeneratedChunk(Level level, long chunkX, long chunkY) : base(level, chunkX, chunkY)
        {
            
        }
    }
}