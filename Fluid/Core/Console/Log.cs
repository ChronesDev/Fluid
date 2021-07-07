using System;

namespace Fluid
{
    public static class Log
    {
        /// <summary>
        /// Determines whether Ascii Color Codes are supported in the server enviroment
        /// </summary>
        public static bool SupportsAsciiColorCodes => false;
        
        /// <summary>
        /// Displays the output in the console
        /// TODO: Apply color codes
        /// </summary>
        public static void Write(object o) => Console.Write(o);
        
        /// <summary>
        /// Displays the output in the console
        /// TODO: Apply color codes
        /// </summary>
        public static void WriteLine(object o) => Console.WriteLine(o);
    }
}