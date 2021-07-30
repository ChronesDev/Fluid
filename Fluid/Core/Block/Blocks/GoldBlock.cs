namespace Fluid.Core
{
    public record GoldBlock : Block
        {
            public override bool Is<T>() => typeof(T) == typeof(GoldBlock);
            public override Block Copy() => new GoldBlock(Chunk, LocalX, LocalY, LocalZ);
            public override Block CopyTo(Level level, long x, long y, long z) => new GoldBlock(level, x, y, z);
            public override Block CopyToLocal(Chunk chunk, ushort localX, ushort localY, ushort localZ) => new GoldBlock(chunk, localX, localY, localZ);

            public override string Name { get; } = "GoldBlock";
        
            public override bool IsSolid { get; } = true;
        
            public override bool IsTransparent { get; } = false;

            public override bool IsFlammable { get; } = false;

            public override float Hardness { get; } = 3f;

            public override float BlastResistance { get; } = 6f;

            public override int BlockID { get; } = BlockId.GoldBlock;

            /// <summary>
            /// Constructor of the GoldBlock block (locally)
            /// </summary>
            /// <param name="chunk">The chunk where the block is in</param>
            /// <param name="localX">The local X position of the block</param>
            /// <param name="localY">The local Y position of the block</param>
            /// <param name="localZ">The local Z position of the block</param>
            public GoldBlock(Chunk chunk, ushort localX, ushort localY, ushort localZ) : base(chunk, localX, localY, localZ)
            {
            
            }
        
            /// <summary>
            /// Constructor of the GoldBlock block (globally)
            /// </summary>
            /// <param name="level">The level where the block is in</param>
            /// <param name="x">The X position of the block</param>
            /// <param name="y">The Y position of the block</param>
            /// <param name="z">The Z position of the block</param>
            public GoldBlock(Level level, long x, long y, long z) : base(level, x, y, z)
            {
            
            }
        
        
        }
}