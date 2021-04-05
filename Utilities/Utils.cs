using System;

namespace Utilities
{
    public class Utils
    {
        public static void WaitForEnter()
        {
            //Indicate wait message
            Console.Write("\nPress <Enter> to continue...");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
    }
}
