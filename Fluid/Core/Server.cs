using System;
using System.Collections.Generic;
using System.Globalization;

namespace Fluid.Core
{
    /// <summary>
    /// This is the core instance of this server, the server itself 
    /// </summary>
    public static partial class Server
    {
        // Instance
        
        /// <summary>
        /// This variable is being used to determine if the server is ready to use
        /// </summary>
        private static bool Initialized { get; set; } = false;

        // Network

        /// <summary>
        /// This variable is being used to determine if the server is ready to use
        /// </summary>
        public static Network Network { get; } = new();

        // Players

        /// <summary>
        /// Stores all OnlinePlayers
        /// </summary>
        public static List<OnlinePlayer> OnlinePlayers { get; private set; } = new();

        /// <summary>
        /// Stores all OfflinePlayers
        /// </summary>
        public static List<OfflinePlayer> OfflinePlayers { get; private set; } = new();

        /// <summary>
        /// Returns all current OnlinePlayers
        /// </summary>
        public static List<OnlinePlayer> Players => OnlinePlayers;

        /// <summary>
        /// Determines the maximal playercount
        /// </summary>
        public static uint MaxPlayerCount { get; private set; } = 32;

        // World

        /// <summary>
        /// Determines if the server saves the game state automatically
        /// </summary>
        public static bool AutoSave { get; private set; } = true;

        // Language
        
        /// <summary>
        /// Determines the language and in which language display messages are being displayed 
        /// </summary>
        public static CultureInfo Language { get; private set; } = CultureInfo.CurrentCulture;
        
        // Worlds
        
        /// <summary>
        /// Stores the references of the current worlds
        /// </summary>
        public static List<Level> Worlds { get; private set; } = new();
        
        // Network
        
        /// <summary>
        /// Handles the incoming and outcoming packets
        /// </summary>
        public static Network network { get; private set; } = new();
        
        // Random

        /// <summary>
        /// This value can generate random numbers
        /// </summary>
        public static Random Random { get; set; } = new();

        /// <summary>
        /// Starts the server
        /// </summary>
        public static void Start()
        {
            if (Initialized) return;
            Initialized = true;
        }
        
        /// <summary>
        /// Stops the server
        /// </summary>
        public static void Stop()
        {
            if (!Initialized) return;
            Initialized = false;
        }

        /// <summary>
        /// Finds a player that has the same name
        /// </summary>
        /// <param name="name">The player name to search for</param>
        /// <returns>Returns the first found player or null if none was found</returns>
        public static OnlinePlayer? GetOnlinePlayerByName(string name) => OnlinePlayers.Find(player => player.PlayerName == name);
        
        /// <summary>
        /// Finds a player that has the same name
        /// </summary>
        /// <param name="name">The player name to search for</param>
        /// <returns>Returns the first found player or null if none was found</returns>
        public static OfflinePlayer? GetOfflinePlayerByName(string name) => OfflinePlayers.Find(player => player.PlayerName == name);

        /// <summary>
        /// Finds an OnlinePlayer that has the same name
        /// </summary>
        /// /// <param name="name">The player name to search for</param>
        /// <returns>Returns the first found OnlinePlayer or null if none was found</returns>
        public static OnlinePlayer? GetPlayerByName(string name) => Players.Find(player => player.PlayerName == name);
        
        /// <summary>
        /// Finds a player that has the same name
        /// </summary>
        /// <param name="name">The player name to search for</param>
        /// <returns>Returns all found players</returns>
        public static List<OnlinePlayer> GetAllOnlinePlayersByName(string name) => OnlinePlayers.FindAll(player => player.PlayerName == name);
        
        /// <summary>
        /// Finds a player that has the same name
        /// </summary>
        /// <param name="name">The player name to search for</param>
        /// <returns>Returns all found players</returns>
        public static List<OfflinePlayer> GetAllOfflinePlayersByName(string name) => OfflinePlayers.FindAll(player => player.PlayerName == name);

        /// <summary>
        /// Finds an OnlinePlayer that has the same name
        /// </summary>
        /// /// <param name="name">The player name to search for</param>
        /// <returns>Returns all found OnlinePlayers</returns>
        public static List<OnlinePlayer> GetAllPlayersByName(string name) => OnlinePlayers.FindAll(player => player.PlayerName == name);

        /// <summary>
        /// Finds a player that has the same name
        /// </summary>
        /// <param name="uuid">The player name to search for</param>
        /// <returns>Returns the first found player or null if none was found</returns>
        public static OnlinePlayer? GetOnlinePlayerByUUID(Guid uuid) => OnlinePlayers.Find(player => player.UUID == uuid);
        
        /// <summary>
        /// Finds a player that has the same name
        /// </summary>
        /// <param name="uuid">The player name to search for</param>
        /// <returns>Returns the first found player or null if none was found</returns>
        public static OfflinePlayer? GetOfflinePlayerByUUID(Guid uuid) => OfflinePlayers.Find(player => player.UUID == uuid);

        /// <summary>
        /// Finds an OnlinePlayer that has the same name
        /// </summary>
        /// /// <param name="uuid">The player name to search for</param>
        /// <returns>Returns the first found OnlinePlayer or null if none was found</returns>
        public static OnlinePlayer? GetPlayerByUUID(Guid uuid) => Players.Find(player => player.UUID == uuid);
        
        /// <summary>
        /// Finds a player that has the same name
        /// </summary>
        /// <param name="uuid">The player name to search for</param>
        /// <returns>Returns all found players</returns>
        public static List<OnlinePlayer> GetAllOnlinePlayersByUUID(Guid uuid) => OnlinePlayers.FindAll(player => player.UUID == uuid);
        
        /// <summary>
        /// Finds a player that has the same name
        /// </summary>
        /// <param name="uuid">The player name to search for</param>
        /// <returns>Returns all found players</returns>
        public static List<OfflinePlayer> GetAllOfflinePlayersByUUID(Guid uuid) => OfflinePlayers.FindAll(player => player.UUID == uuid);

        /// <summary>
        /// Finds an OnlinePlayer that has the same name
        /// </summary>
        /// /// <param name="uuid">The player name to search for</param>
        /// <returns>Returns all found OnlinePlayers</returns>
        public static List<OnlinePlayer> GetAllPlayersByUUID(Guid uuid) => Players.FindAll(player => player.UUID == uuid);
    }
}
