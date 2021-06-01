using System;
using System.Collections.Generic;

namespace Fluid.Core
{
    public static class ConsoleCommands
    {
        public static Dictionary<string, string> HelpMessage = new Dictionary<string, string>()
        {
            {"help", "Displays this message"},
            {"config edit [Property To Edit] [Value]", "Edits a config property"},
            {"config read [Property To Read]", "Reads a config property"},
            {"config save", "Saved current config"}
        };
            
        
        public static void RunCommand(string command)
        {
            string[] statements = command.Split(" ");
            
            switch (statements[0])
            {
                case "help":
                    string dictionaryString = "";  
                    foreach(KeyValuePair < string, string > keyValues in HelpMessage) {  
                        dictionaryString += keyValues.Key + " : " + keyValues.Value + "\n";  
                    }  
                    Console.WriteLine(dictionaryString);
                    break;
                    
                case "config":
                    try
                    {
                        switch (statements[1])
                        {
                            case "edit":
                                Config.EditConfig(statements[2], statements[3]);
                                break;

                            case "read":
                                Config.ReadConfig(statements[2]);
                                break;

                            case "save":
                                Config.SaveConfig();
                                break;
                        }

                        break;
                    }
                    catch {Console.WriteLine("Command not valid");}
                    break;

                default:
                    Console.WriteLine("Command not valid");
                    break;
            }
        }
    }
}