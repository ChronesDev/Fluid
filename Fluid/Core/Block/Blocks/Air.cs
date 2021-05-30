namespace Fluid.Core
{
    /// <summary>
    /// Block: Air
    /// </summary>
    public record Air : Block
    {
        public override bool Is<T>() => typeof(T) == typeof(Air);
        public override Block Copy() => new Air(Chunk, X, Y, Z);

        /// <summary>
        /// Constructor of the Air block
        /// </summary>
        /// <param name="chunk">The chunk where the block is in</param>
        /// <param name="x">The X position of the block</param>
        /// <param name="y">The Y position of the block</param>
        /// <param name="z">The Z position of the block</param>
        public Air(Chunk chunk, long x, long y, long z) : base(chunk, x, y, z)
        {
            
        }
    }
}