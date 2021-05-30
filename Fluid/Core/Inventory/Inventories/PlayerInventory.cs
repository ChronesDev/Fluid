namespace Fluid.Core
{
    public record PlayerInventory : Inventory
    {
        public static PlayerInventory Empty => new();
    }
}