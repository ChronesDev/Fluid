using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluid.Core
{
    public class LoggerManager
    {
        /// <summary>
        /// Return the ConsoleColor to the given ColorCode
        /// </summary>
        /// <param name="colorCode">The ColorCode</param>
        /// <returns>Returns ConsoleColor</returns>
        public static ConsoleColor GetConsoleColorByCode(string colorCode)
        {
            if(colorCode.Equals("§c"))
            {
                return ConsoleColor.Red;
            }
            else if(colorCode.Equals("§0"))
            {
                return ConsoleColor.Black;
            }
            else if (colorCode.Equals("§1"))
            {
                return ConsoleColor.DarkBlue;
            }
            else if (colorCode.Equals("§2"))
            {
                return ConsoleColor.DarkGreen;
            }
            else if (colorCode.Equals("§3"))
            {
                return ConsoleColor.DarkCyan;
            }
            else if (colorCode.Equals("§4"))
            {
                return ConsoleColor.DarkRed;
            }
            else if (colorCode.Equals("§5"))
            {
                return ConsoleColor.DarkMagenta;
            }
            else if (colorCode.Equals("§6"))
            {
                return ConsoleColor.DarkYellow;
            }
            else if (colorCode.Equals("§7"))
            {
                return ConsoleColor.Gray;
            }
            else if (colorCode.Equals("§8"))
            {
                return ConsoleColor.DarkGray;
            }
            else if (colorCode.Equals("§9"))
            {
                return ConsoleColor.Blue;
            }
            else if (colorCode.Equals("§a"))
            {
                return ConsoleColor.Green;
            }
            else if (colorCode.Equals("§b"))
            {
                return ConsoleColor.Cyan;
            }
            else if (colorCode.Equals("§d"))
            {
                return ConsoleColor.Magenta;
            }
            else if (colorCode.Equals("§e"))
            {
                return ConsoleColor.Yellow;
            }
            else if (colorCode.Equals("§f"))
            {
                return ConsoleColor.White;
            }
            else if (colorCode.Equals("§f"))
            {
                return ConsoleColor.White;
            }
            else
            {
                return ConsoleColor.White;
            }
        }
    }
}
