namespace Fluid.Core
{
    /// <summary>
    /// Represents a permission
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

        /// <summary>
        /// Represents the * (star) permission
        /// </summary>
        public static Permission All => new Permission("*");
        
        /// <summary>
        /// Represents no permissions
        /// </summary>
        public static Permission None => new Permission("");
        
        /// <summary>
        /// Represents console permissions
        /// </summary>
        public static Permission Console => new Permission("console");
        
        /// <summary>
        /// Represents operator permissions
        /// </summary>
        public static Permission Operator => new Permission("operator");
    }
}