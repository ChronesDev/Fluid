namespace Fluid.Core
{
    /// <summary>
    /// Represents a Minecraft Chunk that has been generated
    /// </summary>
    public class GeneratedChunk : Chunk
    {
        /// <summary>
        /// Returns a new Generated Chunk
        /// </summary>
        /// <param name="level"></param>
        /// <param name="chunkX"></param>
        /// <param name="chunkY"></param>
        /// <returns></returns>
        public static GeneratedChunk New(Level level, long chunkX, long chunkY) => new GeneratedChunk(level, chunkX, chunkY);

        /// <summary>
        /// Constructor of GeneratedChunk
        /// </summary>
        /// <param name="level">The level where the chunk is in</param>
        /// <param name="chunkX">The X position of the chunk</param>
        /// <param name="chunkY">The Y position of the chunk</param>
        public GeneratedChunk(Level level, long chunkX, long chunkY) : base(level, chunkX, chunkY)
        {
            
        }
    }
}