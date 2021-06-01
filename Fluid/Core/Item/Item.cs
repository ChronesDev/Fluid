using System;

namespace Fluid.Core
{
    public abstract partial record Item
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
        
        protected int _Count = 1;
        protected int _Durability = 1;
        protected bool _IsBroken = false;
        
        /// <summary>
        /// Determines the ItemType
        /// </summary>
        public abstract ItemType Type { get; }
        
        /// <summary>
        /// Determines the maximum count that item can have
        /// </summary>
        public abstract int MaxCount { get; }
        
        /// <summary>
        /// Determines the maximum durability
        /// </summary>
        public abstract int MaxDurability { get; }

        /// <summary>
        /// Determines whether the item updated it's properties that can be seen by the client
        /// </summary>
        public bool IsUpdated { get; protected set; } = true;

        /// <summary>
        /// Determines the item count
        /// </summary>
        public int Count
        {
            get => _Count;
            set { Update(); _Count = value; }
        }

        /// <summary>
        /// Determines the durability
        /// </summary>
        public int Durability
        {
            get => _Durability;
            set { Update(); _Durability = value; }
        }

        /// <summary>
        /// Determines whether the item is broken. Broken items will be deleted on the next inventory update.
        /// </summary>
        public bool IsBroken
        {
            get => _IsBroken;
            set { Update(); _IsBroken = value; }
        }

        /// <summary>
        /// Changes the IsUpdated property to true
        /// </summary>
        public void Update() => IsUpdated = true;

        /// <summary>
        /// Changes the IsUpdated property to false
        /// </summary>
        public void HandleUpdate() => IsUpdated = false;

        /// <summary>
        /// Resets the durability to the maximum durability value
        /// </summary>
        public void ResetDurability() => Durability = MaxDurability;

        /// <summary>
        /// Subtracts 1 durability point
        /// </summary>
        public void UseDurability() => Durability -= 1;

        /// <summary>
        /// Sets IsBroken to true. The item will be deleted on the next inventory update.
        /// </summary>
        public void Break() => IsBroken = true;

        /// <summary>
        /// Checks if the other item is equal to this item
        /// </summary>
        /// <param name="other">The other item</param>
        /// <returns>Returns true if both item are the same</returns>
        public virtual bool Equals(Item? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _Count == other._Count && _Durability == other._Durability && _IsBroken == other._IsBroken && Type == other.Type && MaxCount == other.MaxCount && MaxDurability == other.MaxDurability;
        }

        /// <summary>
        /// Generates a unique hash code of this item
        /// </summary>
        /// <returns>Returns a unique hash code of this item</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_Count, _Durability, _IsBroken, (int) Type, MaxCount, MaxDurability);
        }

        // Ignore this, just a test
        record Sword : Item, Item.ISwingable
        {
            public override bool Is<T>() => typeof(T) == typeof(Sword);
            public override ItemType Type => ItemType.Bed;
            public override int MaxCount => 1;
            public override int MaxDurability => 100;
            public void Swing(ItemSwingEventArgs e)
            {
                e.CustomDamage = 100;
                e.ApplyDamageModifiers = false;
            }
        }
        static void s()
        {
            Sword s = new Sword
            {
                Count = 1,
            };
            s.Count = 2;

            Item item = s;

            if (s is IUseable)
            {
                s.As<IUseable>()?.Use(Item.ItemUseEventArgs.Empty);
            }
        }
    }
}