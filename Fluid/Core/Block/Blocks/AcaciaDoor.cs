namespace Fluid.Core
{
    /// <summary>
    /// Block: AcaciaDoor
    /// </summary>
    public record AcaciaDoor : Block
    {
        public override bool Is<T>() => typeof(T) == typeof(AcaciaDoor);
        public override Block Copy() => new AcaciaDoor(Chunk, LocalX, LocalY, LocalZ);
        public override Block CopyTo(Level level, long x, long y, long z) => new AcaciaDoor(level, x, y, z);
        public override Block CopyToLocal(Chunk chunk, ushort localX, ushort localY, ushort localZ) => new AcaciaDoor(chunk, localX, localY, localZ);

        public override string Name { get; } = "AcaciaDoor";
        
        public override bool IsSolid { get; } = false;
        
        public override bool IsTransparent { get; } = false;

        public override bool IsFlammable { get; } = false;

        public override float Hardness { get; } = 3f;

        public override float BlastResistance { get; } = 3f;

        public override int BlockID { get; } = BlockId.AcaciaDoorBlock;

        /// <summary>
        /// Constructor of the AcaciaDoor block (locally)
        /// </summary>
        /// <param name="chunk">The chunk where the block is in</param>
        /// <param name="localX">The local X position of the block</param>
        /// <param name="localY">The local Y position of the block</param>
        /// <param name="localZ">The local Z position of the block</param>
        public AcaciaDoor(Chunk chunk, ushort localX, ushort localY, ushort localZ) : base(chunk, localX, localY, localZ)
        {
            
        }
        
        /// <summary>
        /// Constructor of the AcaciaDoor block (globally)
        /// </summary>
        /// <param name="level">The level where the block is in</param>
        /// <param name="x">The X position of the block</param>
        /// <param name="y">The Y position of the block</param>
        /// <param name="z">The Z position of the block</param>
        public AcaciaDoor(Level level, long x, long y, long z) : base(level, x, y, z)
        {
            
        }
        
        
    }
}