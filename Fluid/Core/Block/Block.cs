using System.Numerics;

namespace Fluid.Core
{
    public abstract record Block
    {
        /// <summary>
        /// Checks if the other type is the same type of the inheritor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public abstract bool Is<T>();
        
        /// <summary>
        /// Copies this object
        /// </summary>
        /// <returns>Copy of this object</returns>
        public abstract Block Copy();
        
        /// <summary>
        /// Stores the current level
        /// </summary>
        public Level Level { get; protected set; }
        
        /// <summary>
        /// The X position of the block
        /// </summary>
        public long X { get; private set; }
        
        /// <summary>
        /// The Y position of the block
        /// </summary>
        public long Y { get; private set; }
        
        /// <summary>
        /// The Z position of the block
        /// </summary>
        public long Z { get; private set; }

        /// <summary>
        /// Returns a vector to the block position
        /// </summary>
        public Vector3 Position => new(X, Y, Z);

        /// <summary>
        /// Returns a vector to the middle block position
        /// </summary>
        public Vector3 MiddlePosition => new Vector3(X, Y, Z) + new Vector3(0.5f);

        /// <summary>
        /// Constructor of Block
        /// </summary>
        /// <param name="level">The level where the block is in</param>
        protected Block(Level level)
        {
            this.Level = level;
        }

        /// <summary>
        /// Moves the block to the position and updates the changes
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Move(long x, long y, long z)
        {
            (X, Y, Z) = (x, y, z);
        }
    }
}