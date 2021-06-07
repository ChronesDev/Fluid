namespace Fluid.Core
{
    public partial record Item
    {
        public class ItemUseEventArgs : CancelableEventArgs
        {
            /// <summary>
            /// Returns a new empty ItemUseEventArgs class
            /// </summary>
            public new static ItemUseEventArgs Empty => new ItemUseEventArgs();
        }
    }
}