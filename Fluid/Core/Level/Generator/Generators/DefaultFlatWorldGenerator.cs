namespace Fluid.Core
{
    public class DefaultFlatWorldGenerator : ILevelGenerator
    {
        public Chunk GenerateChunk(Level level, long chunkX, long chunkY)
        {
            return new Chunk(level, chunkX, chunkY);
        }
    }
}