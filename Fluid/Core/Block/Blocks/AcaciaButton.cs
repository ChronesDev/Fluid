namespace Fluid.Core
{
    /// <summary>
    /// Block: AcaciaButton
    /// </summary>
    public record AcaciaButton : Block
    {
        public override bool Is<T>() => typeof(T) == typeof(AcaciaButton);
        public override Block Copy() => new AcaciaButton(Chunk, LocalX, LocalY, LocalZ);
        public override Block CopyTo(Level level, long x, long y, long z) => new AcaciaButton(level, x, y, z);
        public override Block CopyToLocal(Chunk chunk, ushort localX, ushort localY, ushort localZ) => new AcaciaButton(chunk, localX, localY, localZ);

        public override string Name { get; } = "AcaciaButton";
        
        public override bool IsSolid { get; } = true;
        
        public override bool IsTransparent { get; } = false;

        public override bool IsFlammable { get; } = false;

        public override float Hardness { get; } = 0.6f;

        public override float BlastResistance { get; } = 0.6f;

        public override int BlockID { get; } = BlockId.AcaciaButton;

        /// <summary>
        /// Constructor of the AcaciaButton block (locally)
        /// </summary>
        /// <param name="chunk">The chunk where the block is in</param>
        /// <param name="localX">The local X position of the block</param>
        /// <param name="localY">The local Y position of the block</param>
        /// <param name="localZ">The local Z position of the block</param>
        public AcaciaButton(Chunk chunk, ushort localX, ushort localY, ushort localZ) : base(chunk, localX, localY, localZ)
        {
            
        }
        
        /// <summary>
        /// Constructor of the AcaciaButton block (globally)
        /// </summary>
        /// <param name="level">The level where the block is in</param>
        /// <param name="x">The X position of the block</param>
        /// <param name="y">The Y position of the block</param>
        /// <param name="z">The Z position of the block</param>
        public AcaciaButton(Level level, long x, long y, long z) : base(level, x, y, z)
        {
            
        }
        
        
    }
}