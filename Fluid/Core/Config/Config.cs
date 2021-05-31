using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Fluid.Core
{
    public class Config
    {
        public static bool WriteConfig()
        {
            if (!File.Exists("properties.json"))
            {
                var properties = new Dictionary<string, string>() 
                {
                    {"ip", "0.0.0.0"},
                    {"port", "19132"},
                    {"whitelist", "false"},
                    {"online_mode", "true"},
                    {"view_distance", "8"},
                    {"max_players", "20"},
                    {"motd", "Fluid Server"}
                };
                
                var options = new JsonSerializerOptions { WriteIndented = true };
                string pretty = JsonSerializer.Serialize(properties, options);
                File.WriteAllText("properties.json", pretty);
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}