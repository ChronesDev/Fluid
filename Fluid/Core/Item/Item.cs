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
        protected string? _DisplayName;
        protected bool _IsBroken;
        private bool _IsUpdated = false;
        
        /// <summary>
        /// Determines the ItemType
        /// </summary>
        public abstract ItemType Type { get; }
        
        /// <summary>
        /// Stores the name of the item
        /// </summary>
        public abstract string Name { get; }
        
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
        public bool IsUpdated => _IsUpdated;

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

        public string? DisplayName
        {
            get => _DisplayName;
            set { Update(); _DisplayName = value; }
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
        public void Update() => _IsUpdated = true;

        /// <summary>
        /// Changes the IsUpdated property to false
        /// </summary>
        public void HandleUpdate() => _IsUpdated = false;

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
        
        // Default Equals
        public virtual bool Equals(Item? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _Count == other._Count && _Durability == other._Durability && _DisplayName == other._DisplayName && _IsBroken == other._IsBroken && Type == other.Type && Name == other.Name && MaxCount == other.MaxCount && MaxDurability == other.MaxDurability;
        }

        // Default GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(_Count, _Durability, _DisplayName, _IsBroken, (int) Type, Name, MaxCount, MaxDurability);
        }
        
        // TEST PULL REQUEST
    }
}