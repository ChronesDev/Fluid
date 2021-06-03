namespace Fluid.Core
{
    public partial record Item
    {
        public class ItemSwingEventArgs : CancelableEventArgs
        {
            /// <summary>
            /// If CustomDamage is null then this will be ignored
            /// </summary>
            public float? CustomDamage { get; set; }
            
            /// <summary>
            /// Determines whether a DamageModifier will be applied
            /// </summary>
            public bool? ApplyDamageModifiers { get; set; }
            
            /// <summary>
            /// Returns a new empty ItemSwingEventArgs class
            /// </summary>
            public new static ItemSwingEventArgs Empty => new ItemSwingEventArgs();
        }
    }
}