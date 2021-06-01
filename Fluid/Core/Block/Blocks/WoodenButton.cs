namespace Fluid.Core
{
    /// <summary>
    /// Block: WoodenButton
    /// aka OakButton
    /// </summary>
    public record WoodenButton : Block
    {
        public override bool Is<T>() => typeof(T) == typeof(WoodenButton);
        public override Block Copy() => new WoodenButton(Chunk, LocalX, LocalY, LocalZ);
        public override Block CopyTo(Level level, long x, long y, long z) => new WoodenButton(level, x, y, z);
        public override Block CopyToLocal(Chunk chunk, ushort localX, ushort localY, ushort localZ) => new WoodenButton(chunk, localX, localY, localZ);

        public override string Name { get; } = "WoodenButton";
        
        public override bool IsSolid { get; } = false;
        
        public override bool IsTransparent { get; } = true;

        public override bool IsFlammable { get; } = true;

        public override float Hardness { get; } = 0.5f;

        public override float BlastResistance { get; } = 0.5f;

        public override int BlockID { get; } = BlockId.WoodenButton;

        /// <summary>
        /// Constructor of the WoodenButton block (locally)
        /// </summary>
        /// <param name="chunk">The chunk where the block is in</param>
        /// <param name="localX">The local X position of the block</param>
        /// <param name="localY">The local Y position of the block</param>
        /// <param name="localZ">The local Z position of the block</param>
        public WoodenButton(Chunk chunk, ushort localX, ushort localY, ushort localZ) : base(chunk, localX, localY, localZ)
        {
            
        }
        
        /// <summary>
        /// Constructor of the WoodenButton block (globally)
        /// </summary>
        /// <param name="level">The level where the block is in</param>
        /// <param name="x">The X position of the block</param>
        /// <param name="y">The Y position of the block</param>
        /// <param name="z">The Z position of the block</param>
        public WoodenButton(Level level, long x, long y, long z) : base(level, x, y, z)
        {
            
        }
        
        
    }
}