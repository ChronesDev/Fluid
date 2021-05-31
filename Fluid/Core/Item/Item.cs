using System;

namespace Fluid.Core
{
    public abstract record Item
    {
        /// <summary>
        /// Determines the ItemType
        /// </summary>
        public abstract ItemType Type { get; }
        
        /// <summary>
        /// Determines the maximum count that item can have
        /// </summary>
        public abstract int MaxCount { get; }

        /// <summary>
        /// Stores the item count
        /// </summary>
        public int Count { get; } = 1;
    }
}