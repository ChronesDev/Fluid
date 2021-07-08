namespace Fluid.Core
{
    /// <summary>
    /// Block: Cobblestone
    /// </summary>
    public record Cobblestone : Block
    {
        public override bool Is<T>() => typeof(T) == typeof(Cobblestone);
        public override Block Copy() => new Cobblestone(Chunk, LocalX, LocalY, LocalZ);
        public override Block CopyTo(Level level, long x, long y, long z) => new Cobblestone(level, x, y, z);
        public override Block CopyToLocal(Chunk chunk, ushort localX, ushort localY, ushort localZ) => new Cobblestone(chunk, localX, localY, localZ);

        public override string Name { get; } = "Cobblestone";
        
        public override bool IsSolid { get; } = true;
        
        public override bool IsTransparent { get; } = false;

        public override bool IsFlammable { get; } = false;

        public override float Hardness { get; } = 2f;

        public override float BlastResistance { get; } = 6f;

        public override int Id { get; } = BlockId.Cobblestone;

        /// <summary>
        /// Constructor of the Cobblestone block (locally)
        /// </summary>
        /// <param name="chunk">The chunk where the block is in</param>
        /// <param name="localX">The local X position of the block</param>
        /// <param name="localY">The local Y position of the block</param>
        /// <param name="localZ">The local Z position of the block</param>
        public Cobblestone(Chunk chunk, ushort localX, ushort localY, ushort localZ) : base(chunk, localX, localY, localZ)
        {
            
        }
        
        /// <summary>
        /// Constructor of the Cobblestone block (globally)
        /// </summary>
        /// <param name="level">The level where the block is in</param>
        /// <param name="x">The X position of the block</param>
        /// <param name="y">The Y position of the block</param>
        /// <param name="z">The Z position of the block</param>
        public Cobblestone(Level level, long x, long y, long z) : base(level, x, y, z)
        {
            
        }
        
        
    }
}