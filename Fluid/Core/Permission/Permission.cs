namespace Fluid.Core
{
    /// <summary>
    /// Is being used to determine the permissions
    /// </summary>
    public struct Permission
    {
        /// <summary>
        /// Stores the permission identifier
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Permission(string id)
        {
            Id = id;
        }
    }
}