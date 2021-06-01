namespace Fluid.Core
{
    /// <summary>
    /// Block: OakDoor
    /// </summary>
    public record OakDoor : Block
    {
        public override bool Is<T>() => typeof(T) == typeof(OakDoor);
        public override Block Copy() => new OakDoor(Chunk, LocalX, LocalY, LocalZ);
        public override Block CopyTo(Level level, long x, long y, long z) => new OakDoor(level, x, y, z);
        public override Block CopyToLocal(Chunk chunk, ushort localX, ushort localY, ushort localZ) => new OakDoor(chunk, localX, localY, localZ);

        public override string Name { get; } = "OakDoor";
        
        public override bool IsSolid { get; } = false;
        
        public override bool IsTransparent { get; } = false;

        public override bool IsFlammable { get; } = true;

        public override float Hardness { get; } = 3f;

        public override float BlastResistance { get; } = 3f;

        public override int BlockID { get; } = BlockId.OakDoorBlock;

        /// <summary>
        /// Constructor of the OakDoor block (locally)
        /// </summary>
        /// <param name="chunk">The chunk where the block is in</param>
        /// <param name="localX">The local X position of the block</param>
        /// <param name="localY">The local Y position of the block</param>
        /// <param name="localZ">The local Z position of the block</param>
        public OakDoor(Chunk chunk, ushort localX, ushort localY, ushort localZ) : base(chunk, localX, localY, localZ)
        {
            
        }
        
        /// <summary>
        /// Constructor of the OakDoor block (globally)
        /// </summary>
        /// <param name="level">The level where the block is in</param>
        /// <param name="x">The X position of the block</param>
        /// <param name="y">The Y position of the block</param>
        /// <param name="z">The Z position of the block</param>
        public OakDoor(Level level, long x, long y, long z) : base(level, x, y, z)
        {
            
        }
        
        
    }
}