using Fluid.Core;
using System;

namespace Fluid.Core
{
    public abstract class Player : LivingEntity
    {
        public override bool Is<T>() => typeof(T) == typeof(Player);

        /// <summary>
        /// Stores the original PlayerName
        /// </summary>
        public string PlayerName { get; protected set; } = String.Empty;
        
        /// <summary>
        /// Stores the UUID of the player
        /// </summary>
        public Guid UUID { get; protected set; } = Guid.Empty;

        /// <summary>
        /// Stores the player inventory
        /// </summary>
        public PlayerInventory Inventory { get; set; } = PlayerInventory.Empty;


        protected Player(Level level) : base(level)
        {
        }
    }
}