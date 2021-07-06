using System;
using System.Collections.Generic;

namespace Fluid.Core
{
    public static partial class Server
    {
        public static class Commands
        {
            public static List<Command> RegisteredCommands { get; private set; } = new();
            
            /// <summary>
            /// Registers a command. An exception is being thrown if a command with the same name exists
            /// </summary>
            public static void RegisterCommand(Command command)
            {
                if (RegisteredCommands.Contains(command)) 
                    throw new Exception("A duplicate has been found.");
                
                if (RegisteredCommands.Find(c => c.FullName == command.FullName) is not null)
                    throw new Exception("A duplicate with the same FullName has been found.");
                
                RegisteredCommands.Add(command);
            }
        }
    }
}