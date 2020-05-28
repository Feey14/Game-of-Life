using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class Messages
    {
        public static void WidthInputMessage()
        {
            Console.WriteLine("Enter Matrix Width");
        }
        public static void HeightInputMessage()
        {
            Console.WriteLine("Enter Matrix Height");
        }
        public static void DisplayError(string message)
        {
            Console.WriteLine("Error: {0}", message);
        }
        public static void PrintLine(string line)
        {
            Console.WriteLine(line);
        }
        public static void TerminatingApplicationMessage()
        {
            Console.WriteLine("Terminating the application...");
        }
        public static void PressKeyToStopMessage()
        {
            Console.WriteLine("Press any key to stop");
        }
    }
}
