using System;

namespace Fluid.Core
{
    public abstract record Inventory
    {
        /// <summary>
        /// Checks if the other type is the same type of the inheritor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The result</returns>
        public abstract bool Is<T>();

        /// <summary>
        /// Casts this object to T
        /// </summary>
        /// <typeparam name="T">The type to cast to</typeparam>
        /// <returns>Returns the casted type of this object</returns>
        public T? As<T>() where T : class => this as T;
        
        /// <summary>
        /// Determines the ItemSlot count 
        /// </summary>
        public abstract int SlotCount { get; }
        
        /// <summary>
        /// Returns all available ItemSlots
        /// </summary>
        public abstract ItemSlot[] AllSlots { get; }

        /// <summary>
        /// Returns an ItemSlot by index. Can throw an OutOfRangeException if an invalid index is specified.
        /// </summary>
        /// <param name="index">The index to get the item from</param>
        /// <returns>Returns the ItemSlot</returns>
        public abstract ref ItemSlot GetSlot(int index);
        
        /// <summary>
        /// Sets the ItemSlot at the index. Can throw an OutOfRangeException if an invalid index is specified.
        /// </summary>
        /// <param name="slot">The ItemSlot</param>
        /// <param name="index">The index</param>
        public abstract void SetSlot(ItemSlot slot, int index);

        /// <summary>
        /// Clears all slots
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Sets the item at the index. Can throw an OutOfRangeException if an invalid index is specified.
        /// </summary>
        /// <param name="item">The Item</param>
        /// <param name="index">The index</param>
        public void Set(Item? item, int index)
        {
            AtSlot(index).Set(item);
        }

        /// <summary>
        /// Gets the Item from the slot index. Can throw an OutOfRangeException if an invalid index is specified.
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>Returns the Item from the slot index</returns>
        public Item? Get(int index) => GetSlot(index).Item;
        
        /// <summary>
        /// Gets a reference to the item by the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>Returns a reference to the item by the index</returns>
        public Item? At(int index) => GetSlot(index).Item;

        /// <summary>
        /// Gets a reference to the ItemSlot by the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>Returns a reference to the ItemSlot by the index</returns>
        public ref ItemSlot AtSlot(int index) => ref GetSlot(index);

        /// <summary>
        /// Swaps the two ItemSlots
        /// </summary>
        /// <param name="indexLeft">The left index</param>
        /// <param name="indexRight">The right index</param>
        public void Swap(int indexLeft, int indexRight)
        {
            ItemSlot.Swap(ref AtSlot(indexLeft), ref AtSlot(indexRight));
        }
        
        /// <summary>
        /// Gets a reference to the ItemSlot by the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>Returns a reference to the item by the index</returns>
        public Item? this[int index]
        {
            get => At(index);
            set => AtSlot(index).Item = value;
        }

        static void s()
        {
            Inventory i = null!;
            ref ItemSlot s = ref i.AtSlot(10);
            i[10].DisplayName = "Hello World";
        }
    }
}
