namespace Fluid.Core
{
    public static partial class Items
    {
        public record TestItem : Item
        {
            public override bool Is<T>() => typeof(T) == typeof(TestItem);

            public override ItemType Type => ItemType.Air;
            public override string Name => "TestItem";
            public override int MaxCount => Count64;
            public override int MaxDurability => 1;
        }
    }
}