namespace Fluid.Core
{
    /// <summary>
    /// Block: Air
    /// </summary>
    public record Air : Block
    {
        public override bool Is<T>() => typeof(T) == typeof(Air);
        public override Block Copy() => new Air(Chunk, LocalX, LocalY, LocalZ);
        public override Block CopyTo(Level level, long x, long y, long z) => new Air(level, x, y, z);
        public override Block CopyToLocal(Chunk chunk, ushort localX, ushort localY, ushort localZ) => new Air(chunk, localX, localY, localZ);

        /// <summary>
        /// Constructor of the Air block (locally)
        /// </summary>
        /// <param name="chunk">The chunk where the block is in</param>
        /// <param name="localX">The local X position of the block</param>
        /// <param name="localY">The local Y position of the block</param>
        /// <param name="localZ">The local Z position of the block</param>
        public Air(Chunk chunk, ushort localX, ushort localY, ushort localZ) : base(chunk, localX, localY, localZ)
        {
            
        }
        
        /// <summary>
        /// Constructor of the Air block (globally)
        /// </summary>
        /// <param name="level">The level where the block is in</param>
        /// <param name="x">The X position of the block</param>
        /// <param name="y">The Y position of the block</param>
        /// <param name="z">The Z position of the block</param>
        public Air(Level level, long x, long y, long z) : base(level, x, y, z)
        {
            
        }
        
        
    }
}