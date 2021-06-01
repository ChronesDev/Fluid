namespace Fluid.Core
{
    public abstract record Item
    {
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
        /// Determines whether the item updated it's properties
        /// </summary>
        public bool Updated { get; protected set; } = true;

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
        /// Changes the Updated property to true
        /// </summary>
        public void Update() => Updated = true;

        /// <summary>
        /// Changes the Updated property to false
        /// </summary>
        public void HandleUpdate() => Updated = false;

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

        
        // Ignore this, just a test
        record Sword : Item
        {
            public override ItemType Type => ItemType.Bed;
            public override int MaxCount => 1;
            public override int MaxDurability => 100;
        }
        static void s()
        {
            Sword s = new Sword();
            s.Count = 2;
        }
    }
}