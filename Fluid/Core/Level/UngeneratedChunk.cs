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

        public UngeneratedChunk(Level level, long chunkX, long chunkY) : base(level, chunkX, chunkY)
        {
            
        }
    }
}