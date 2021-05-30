using System;

namespace Fluid.Core
{
    /// <summary>
    /// Represents a Minecraft Level
    /// </summary>
    public class Level : IDisposable
    {
        // Chat
        
        /// <summary>
        /// This is the holder of the WorldChat where players can communicate inside of this world
        /// </summary>
        public WorldChat chat = new();
        
        // Random
        
        /// <summary>
        /// This value can generate random numbers
        /// </summary>
        public static Random Random { get; set; } = new();
        
        public 

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}