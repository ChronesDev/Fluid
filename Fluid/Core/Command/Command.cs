namespace Fluid.Core
{
    public abstract class Command
    {
        /// <summary>
        /// Is being displayed when calling /help
        /// </summary>
        public abstract string FullName { get; }
        
        /// <summary>
        /// Is being used to display the command description
        /// </summary>
        public abstract string Description { get; }
        
        /// <summary>
        /// Is being used to determine the command name /mycommand...
        /// </summary>
        public abstract string CommandName { get; }
    }
}