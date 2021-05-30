namespace Fluid.Core
{
    public record ShinyTestBlock : Block
    {
        public override bool Is<T>() => typeof(T) == typeof(Air);
        public override Block Copy() => new ShinyTestBlock();
    }
}