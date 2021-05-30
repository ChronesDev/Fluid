using System;

namespace Fluid.Core
{
    public abstract class Entity : IDisposable
    {
        /// <summary>
        /// Checks if the other type is the same type of the inheritor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The result</returns>
        public abstract bool Is<T>();

        /// <summary>
        /// Stores a reference to the world
        /// </summary>
        public Level World { get; set; }

        /// <summary>
        /// Constructor of Entity
        /// </summary>
        /// <param name="world">The world where the entity is in</param>
        protected Entity(Level world)
        {
            this.World = world;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}