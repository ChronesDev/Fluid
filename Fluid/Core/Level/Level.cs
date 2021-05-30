using System;
using System.Collections.Generic;
using System.Numerics;

namespace Fluid.Core
{
    /// <summary>
    /// Represents a Minecraft Level
    /// </summary>
    public class Level
    {
        // Chat
        
        /// <summary>
        /// This is the holder of the LevelChat where players can communicate inside of this world
        /// </summary>
        public LevelChat Chat = new();
        
        // Random
        
        /// <summary>
        /// This value can generate random numbers
        /// </summary>
        public Random Random { get; } = new();

        /// <summary>
        /// Stores the LevelGenerator that allows generating new chunks
        /// </summary>
        public ILevelGenerator LevelGenerator { get; protected set; } = new DefaultFlatWorldGenerator();

        /// <summary>
        /// Gets a chunk from the world position
        /// </summary>
        /// <param name="position">The position to search for</param>
        /// <returns>Returns the chunk or null if the chunk hasn't been loaded yet</returns>
        public Chunk? GetChunkFromPosition(Vector3 position)
        {
            return null;
        }

        /// <summary>
        /// Gets a chunk from the chunk position
        /// </summary>
        /// <param name="chunkPosition">The chunk position to search for</param>
        /// <returns>Returns the chunk or null if the chunk hasn't been loaded yet</returns>
        public Chunk? GetChunkFromChunkPosition(Vector3 chunkPosition)
        {
            return null;
        }
    }
}