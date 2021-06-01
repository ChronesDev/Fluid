namespace Fluid.Core
{
    public record ShinyTestBlock : Block
    {
        public ShinyTestBlock(Chunk chunk, ushort localX, ushort localY, ushort localZ) : base(chunk, localX, localY, localZ)
        {
        }

        public ShinyTestBlock(Level level, long x, long y, long z) : base(level, x, y, z)
        {
        }

        public override bool Is<T>()
        {
            throw new System.NotImplementedException();
        }

        public override Block Copy()
        {
            throw new System.NotImplementedException();
        }

        public override Block CopyTo(Level level, long x, long y, long z)
        {
            throw new System.NotImplementedException();
        }

        public override Block CopyToLocal(Chunk chunk, ushort localX, ushort localY, ushort localZ)
        {
            throw new System.NotImplementedException();
        }

        public override string Name { get; }
        public override bool IsSolid { get; }
        public override bool IsTransparent { get; }
        public override bool IsFlammable { get; }
        public override float Hardness { get; }
        public override float BlastResistance { get; }
        public override int BlockID { get; }
    }
}