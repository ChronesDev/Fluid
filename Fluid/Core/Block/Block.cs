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
        /// Stores the current Chunk
        /// </summary>
        public Chunk Chunk { get; private set; }

        /// <summary>
        /// Stores the current level
        /// </summary>
        public Level Level => Chunk.Level;

        // TODO: Fix X, Y, Z (they will be replaced with Local X, Y, Z)
        
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
        /// The local X position of the block
        /// </summary>
        public long LocalX { get; private set; }

        /// <summary>
        /// The local Y position of the block
        /// </summary>
        public long LocalY { get; private set; }
        
        /// <summary>
        /// The local Z position of the block
        /// </summary>
        public long LocalZ { get; private set; }
        
        /// <summary>
        /// Returns a vector to the block position
        /// </summary>
        public Vector3 LocalPosition => new(LocalX, LocalY, LocalZ);

        /// <summary>
        /// Returns a vector to the middle block position
        /// </summary>
        public Vector3 LocalMiddlePosition => new Vector3(LocalX, LocalY, LocalZ) + new Vector3(0.5f);

        /// <summary>
        /// Constructor of Block
        /// </summary>
        /// <param name="chunk">The chunk where the block is in</param>
        /// <param name="x">The X position of the block</param>
        /// <param name="y">The Y position of the block</param>
        /// <param name="z">The Z position of the block</param>
        protected Block(Chunk chunk, long x, long y, long z)
        {
            this.Chunk = chunk;
        }

        // TODO: Finish Move
        
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