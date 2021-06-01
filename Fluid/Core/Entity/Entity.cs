namespace Fluid.Core
{
    public abstract class Entity
    {
        /// <summary>
        /// Checks if the other type is the same type of the inheritor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The result</returns>
        public abstract bool Is<T>();

        /// <summary>
        /// Casts this object to T
        /// </summary>
        /// <typeparam name="T">The type to cast to</typeparam>
        /// <returns>Returns the casted type of this object</returns>
        public T? As<T>() where T : Entity => this as T;

        /// <summary>
        /// Stores a reference to the world
        /// </summary>
        public Level Level { get; set; }
        
        /// <summary>
        /// Determines the position of this entity
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Calculates the current chunk of the Position property. There is no guarantee that this Chunk does contain the entity 
        /// </summary>
        /// <returns>The Chunk where the entity is in</returns>
        public Chunk? CurrentChunk => Level.GetChunkFromPosition(Position);
        public Chunk? CurrentChunk => Level.FindChunkFromPosition(Position);

        /// <summary>
        /// Stores where the entity is currently, is being updated by the tick or teleport event
        /// </summary>
        public Vector3 LerpPosition { get; protected set; }
        
        /// <summary>
        /// Stores the current chunk where the entity is in
        /// </summary>
        public Chunk LerpChunk { get; protected set; }
        
        /// <summary>
        /// Constructor of Entity
        /// </summary>
        /// <param name="level">The level where the entity is in</param>
        protected Entity(Level level)
        {
            this.Level = level;
        }

        public void Teleport(Vector3 position)
        {
            Position = position;
            LerpPosition = position;
            LerpChunk = Level.GetChunkFromPosition(Position);
        }
    }
}