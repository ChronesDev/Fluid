namespace Fluid.Core
{
    public class EventArgs : System.EventArgs
    {
        /// <summary>
        /// Determines whether this event is handled
        /// </summary>
        public bool Handled { get; set; }

        /// <summary>
        /// Returns a new empty EventArgs class
        /// </summary>
        public new static EventArgs Empty => new EventArgs();
    }
}