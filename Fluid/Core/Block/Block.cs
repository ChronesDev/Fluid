using System.Numerics;

namespace Fluid.Core
{
    public abstract record Block : IDestroyable
    {
        #region ImportantOverrideableMethods
        
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
        /// Copies this object to another position 
        /// </summary>
        /// <param name="level">The level where the block is in</param>
        /// <param name="x">The X position of the block</param>
        /// <param name="y">The Y position of the block</param>
        /// <param name="z">The Z position of the block</param>
        /// <returns>The copied Block</returns>
        public abstract Block CopyTo(Level level, long x, long y, long z);

        /// <summary>
        /// Copies this object to another position 
        /// </summary>
        /// <param name="x">The X position of the block</param>
        /// <param name="y">The Y position of the block</param>
        /// <param name="z">The Z position of the block</param>
        /// <returns>The copied Block</returns>
        public Block CopyTo(long x, long y, long z) => CopyTo(Level, x, y, z);

        /// <summary>
        /// Copies this object to another position 
        /// </summary>
        /// <param name="chunk">The chunk where the copied block is in</param>
        /// <param name="localX">The local X position of the block</param>
        /// <param name="localY">The local Y position of the block</param>
        /// <param name="localZ">The local Z position of the block</param>
        /// <returns>The copied Block</returns>
        public abstract Block CopyToLocal(Chunk chunk, ushort localX, ushort localY, ushort localZ);

        #endregion

        #region OverrideablePorperties

        public abstract string Name { get; }

        /// <summary>
        /// Determines the ID of the block
        /// </summary>
        public abstract int Id { get; }

        /// <summary>
        /// Determines if the block is solid
        /// </summary>
        public abstract bool IsSolid { get; }

        /// <summary>
        /// Determines if the block is transparent. Entities can see through the block if true.
        /// </summary>
        public abstract bool IsTransparent { get; }

        /// <summary>
        /// Determines if the block is flammable.
        /// </summary>
        
        public abstract bool IsFlammable { get; }

        /// <summary>
        /// Determines the hardness of the block
        /// </summary>
        public abstract float Hardness { get; }

        /// <summary>
        /// Determines the blast resistance of the block
        /// </summary>
        public abstract float BlastResistance { get; }

        #endregion
        
        #region Properties

        /// <summary>
        /// Stores the current Chunk
        /// WARNING: You should NEVER change this value on your own unless you know what you are doing
        /// </summary>
        public Chunk Chunk { get; set; }

        /// <summary>
        /// Stores the current level
        /// </summary>
        public Level Level => Chunk.Level;

        // TODO: Fix X, Y, Z (they will be replaced with Local X, Y, Z)

        /// <summary>
        /// The X position of the block
        /// </summary>
        public long X => 0;
        
        /// <summary>
        /// The Y position of the block
        /// </summary>
        public long Y => 0;
        
        /// <summary>
        /// The Z position of the block
        /// </summary>
        public long Z => 0;
        
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
        /// WARNING: You should NEVER change this value on your own unless you know what you are doing
        /// </summary>
        public ushort LocalX { get; set; }

        /// <summary>
        /// The local Y position of the block
        /// WARNING: You should NEVER change this value on your own unless you know what you are doing
        /// </summary>
        public ushort LocalY { get; set; }
        
        /// <summary>
        /// The local Z position of the block
        /// WARNING: You should NEVER change this value on your own unless you know what you are doing
        /// </summary>
        public ushort LocalZ { get; set; }
        
        /// <summary>
        /// Returns a vector to the block position
        /// </summary>
        public Vector3 LocalPosition => new(LocalX, LocalY, LocalZ);

        /// <summary>
        /// Returns a vector to the middle block position
        /// </summary>
        public Vector3 LocalMiddlePosition => new Vector3(LocalX, LocalY, LocalZ) + new Vector3(0.5f);

        #endregion

        /// <summary>
        /// Constructor of Block (locally)
        /// </summary>
        /// <param name="chunk">The chunk where the block is in</param>
        /// <param name="localX">The local X position of the block</param>
        /// <param name="localY">The local Y position of the block</param>
        /// <param name="localZ">The local Z position of the block</param>
        protected Block(Chunk chunk, ushort localX, ushort localY, ushort localZ)
        {
            this.Chunk = chunk;
        }

        /// <summary>
        /// Constructor of Block (globally)
        /// </summary>
        /// <param name="level">The level where the block is in</param>
        /// <param name="x">The X position of the block</param>
        /// <param name="y">The Y position of the block</param>
        /// <param name="z">The Z position of the block</param>
        protected Block(Level level, long x, long y, long z)
        {
            // TODO: Finish this
            this.Chunk = level.GetChunkFromPosition(new Vector3());
        }

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
            Chunk = null!;
        }

        /// <summary>
        /// Moves the block to the position and updates the changes
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Move(long x, long y, long z)
        {
            // TODO: Finish Move
        }
    }
}