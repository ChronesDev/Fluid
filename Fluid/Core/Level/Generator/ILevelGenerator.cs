namespace Fluid.Core
{
    public interface ILevelGenerator
    {
        Chunk GenerateChunk(Level level, long chunkX, long chunkY);
    }
}