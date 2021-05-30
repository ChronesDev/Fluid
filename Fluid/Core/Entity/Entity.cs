using System;

namespace Fluid.Core
{
    public abstract class Entity
    {
        /// <summary>
        /// Checks if the other type is the same type of the inheritor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The result</returns>
        public abstract bool Is<T>();

        /// <summary>
        /// Casts this object to T
        /// </summary>
        /// <typeparam name="T">The type to cast to</typeparam>
        /// <returns>Returns the casted type of this object</returns>
        public T? As<T>() where T : Entity => this as T;

        /// <summary>
        /// Stores a reference to the world
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// Constructor of Entity
        /// </summary>
        /// <param name="level">The level where the entity is in</param>
        protected Entity(Level level)
        {
            this.Level = level;
        }
    }
}