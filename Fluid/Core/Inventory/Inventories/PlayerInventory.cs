using System;

namespace Fluid.Core
{
    public record PlayerInventory : Inventory
    {
        public static PlayerInventory Empty => new();
        
        public override bool Is<T>() => typeof(T) == typeof(PlayerInventory);

        public override int SlotCount => Slots.Length;
        public override ItemSlot[] AllSlots => Slots;
        public override ref ItemSlot GetSlot(int index) => ref Slots[index];
        public override void SetSlot(ItemSlot slot, int index) => Slots[index] = slot;
        public override void Clear() => Array.Clear(Slots, 0, Slots.Length);

        /// <summary>
        /// Stores all ItemSlots
        /// </summary>
        public ItemSlot[] Slots { get; private set; } = new ItemSlot[36];
    }
}