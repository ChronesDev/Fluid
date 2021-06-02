using System;

namespace Fluid.Core
{
    public struct ItemSlot : IEquatable<ItemSlot>
    {
        public static ItemSlot Empty => new ItemSlot();
        
        private Item? _Item;
        private bool _IsUpdated;

        /// <summary>
        /// Returns the stored item
        /// </summary>
        public Item? Item
        {
            get => _Item;
            set { Update(); _Item = value; }
        }
        
        /// <summary>
        /// Determines whether the item updated it's properties that can be seen by the client
        /// </summary>
        public bool IsUpdated => _IsUpdated || (_Item?.IsUpdated ?? false);

        /// <summary>
        /// Determines whether this slot has an item
        /// </summary>
        public bool HasItem => _Item is not null;

        /// <summary>
        /// Constructor of ItemSlot
        /// </summary>
        public ItemSlot(Item? item = null)
        {
            _Item = item;
            _IsUpdated = true;
        }
        
        /// <summary>
        /// Changes the IsUpdated property to true
        /// </summary>
        public void Update() => _IsUpdated = true;

        /// <summary>
        /// Changes the IsUpdated property to false
        /// </summary>
        public void HandleUpdate() { _IsUpdated = false; _Item?.HandleUpdate(); }

        /// <summary>
        /// Swaps the two items from the two item slots
        /// </summary>
        /// <param name="other">The other ItemSlot</param>
        public void Swap(ref ItemSlot other) => (Item, other.Item) = (other.Item, Item);
        
        /// <summary>
        /// Determines whether the ItemSlot's item is equal to the other item
        /// </summary>
        /// <param name="other">The other Item</param>
        /// <returns>Returns true if both items are equal</returns>
        public bool Equals(Item? other)
        {
            return Item?.Equals(other) ?? false;
        }

        /// <summary>
        /// Determines whether the ItemSlot's item is equal to the other item
        /// </summary>
        /// <param name="left">The ItemSlot</param>
        /// <param name="right">The other Item</param>
        /// <returns>Returns true if both items are equal</returns>
        public static bool operator ==(ItemSlot left, Item? right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether the ItemSlot's item is not equal to the other item
        /// </summary>
        /// <param name="left">The ItemSlot</param>
        /// <param name="right">The other Item</param>
        /// <returns>Returns true if both items are not equal</returns>
        public static bool operator !=(ItemSlot left, Item? right)
        {
            return !left.Equals(right);
        }
        
        // Default Equals
        public bool Equals(ItemSlot other)
        {
            return Equals(_Item, other._Item);
        }

        // Default Equals
        public override bool Equals(object? obj)
        {
            return (obj is Item && Equals(obj as Item)) || (obj is ItemSlot other && Equals(other));
        }
        
        // Default GetHashCode
        public override int GetHashCode()
        {
            return (_Item != null ? _Item.GetHashCode() : 0);
        }

        // Default == Operator
        public static bool operator ==(ItemSlot left, ItemSlot right)
        {
            return left.Equals(right);
        }

        // Default != Operator
        public static bool operator !=(ItemSlot left, ItemSlot right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Swaps the two items from the two item slots
        /// </summary>
        /// <param name="left">The left ItemSlot</param>
        /// <param name="right">The right ItemSlot</param>
        public static void Swap(ref ItemSlot left, ref ItemSlot right) => (left.Item, right.Item) = (right.Item, left.Item);
    }
}