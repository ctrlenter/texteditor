using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    public class console
    {

        public static void info(object message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"[{DateTime.UtcNow.ToString("hh:mm:ss")}] [INFO] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message+"\n");

        }

        public static void log(object message, bool newLine = true)
        {
            if (newLine)
                Console.WriteLine(message);
            else
                Console.Write(message);            
        }

        public static void error(object message)
        {
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.Write(message + "\n");
            Console.ForegroundColor = System.ConsoleColor.White;
        }
   
    }
}
 