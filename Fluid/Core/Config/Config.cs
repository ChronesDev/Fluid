using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace Fluid.Core
{
    public class Config
    {
        public static Dictionary<string, string> Properties = new Dictionary<string, string>() 
        {
            {"ip", "0.0.0.0"}, 
            {"port", "19132"}, 
            {"whitelist", "false"},
            {"online_mode", "true"}, 
            {"view_distance", "8"}, 
            {"max_players", "20"}, 
            {"motd", "Fluid Server"}
        };
        
        public static void SaveConfig()
        {
            var options = new JsonSerializerOptions {WriteIndented = true};
            string pretty = System.Text.Json.JsonSerializer.Serialize(Properties, options);
            File.WriteAllText("properties.json", pretty); 
        }

        public static string ReadConfig(string propertyToRead)
        {
            if (Properties.ContainsKey(propertyToRead))
            {
                return Properties[propertyToRead];
            }
            else
            {
                Console.WriteLine("Property Invalid");
                return null;
            }
        }
        
        public static bool EditConfig(string propertyToEdit, string value)
        {
            if (Properties.ContainsKey(propertyToEdit))
            {
                Properties[propertyToEdit] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Dictionary<string, string> LoadConfig()
        {
            if (File.Exists("properties.json"))
            {
                string json = File.ReadAllText("properties.json");
                Dictionary<string, string> config = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                Properties = config;
                return Properties;
            }
            else 
            { 
                return null; 
            }
        }
    }
}