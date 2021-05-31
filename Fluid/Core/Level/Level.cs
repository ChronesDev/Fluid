using System;
using System.Collections.Generic;
using System.Numerics;

namespace Fluid.Core
{
    /// <summary>
    /// Represents a Minecraft Level
    /// </summary>
    public class Level : IDestroyable
    {
        // Chat

        /// <summary>
        /// This is the holder of the LevelChat where players can communicate inside of this world
        /// </summary>
        public LevelChat Chat { get; protected set; } = new();

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
        /// This method can be overwritten if needed
        /// </summary>
        protected virtual void OnDestroying() { }
        
        /// <summary>
        /// Implements IDestroyable.Destroy
        /// </summary>
        public void Destroy()
        {
            OnDestroying();
            LevelGenerator = null!;
        }
        
        /// <summary>
        /// Gets a chunk from the world position
        /// </summary>
        /// <param name="position">The position to search for</param>
        /// <returns>Returns the chunk or null if the chunk hasn't been loaded yet</returns>
        public Chunk? FindChunkFromPosition(Vector3 position)
        {
            // TODO: Finish this
            return null;
        }

        /// <summary>
        /// Gets a chunk from the chunk position
        /// </summary>
        /// <param name="chunkPosition">The chunk position to search for</param>
        /// <returns>Returns the chunk or null if the chunk hasn't been loaded yet</returns>
        public Chunk? FindChunkFromChunkPosition(Vector3 chunkPosition)
        {
            // TODO: Finish this
            return null;
        }

        /// <summary>
        /// Gets a chunk from the world position
        /// </summary>
        /// <param name="position">The position to search for</param>
        /// <returns>Returns the chunk or a new UngeneratedChunk if no existing chunk has been loaded yet</returns>
        public Chunk GetChunkFromPosition(Vector3 position)
        {
            // TODO: Finish this
            return new UngeneratedChunk(this, (long)position.X, (long)position.Y);
        }
        
    }
}