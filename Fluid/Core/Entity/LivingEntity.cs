using System;

namespace Fluid.Core
{
    public abstract class LivingEntity : Entity
    {
        private float _Health;
        private float _MaxHealth = 20f;
        
        /// <summary>
        /// Stores the health value of the entity
        /// </summary>
        public float Health
        {
            get => _Health;
            set { _Health = MathF.Max(0, MathF.Min(0, value)); }
        }

        /// <summary>
        /// Determines the maximum health value
        /// </summary>
        public float MaxHealth
        {
            get => _MaxHealth;
            set { 
                _MaxHealth = MathF.Max(0, value);
                Health = MathF.Min(Health, _MaxHealth);
            }
        }

        /// <summary>
        /// Constructor of LivingEntity
        /// </summary>
        /// <param name="level">The level where the entity is in</param>
        protected LivingEntity(Level level) : base(level)
        {
            
        }
    }
}