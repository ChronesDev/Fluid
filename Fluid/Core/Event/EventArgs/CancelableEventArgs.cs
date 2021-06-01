namespace Fluid.Core
{
    /// <summary>
    /// EventArgs that can be cancelled
    /// </summary>
    public class CancelableEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
        
        /// <summary>
        /// Returns a new empty CancelableEventArgs class
        /// </summary>
        public new static CancelableEventArgs Empty => new CancelableEventArgs();
    }
}