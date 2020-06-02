using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class UserInput
    {
        public static IGameOfLife Capture()
        {
            int Width;
            Messages.WidthInputMessage();
            string input = Console.ReadLine();
            Int32.TryParse(input, out Width);

            int Height;
            Messages.HeightInputMessage();
            input = Console.ReadLine();
            Int32.TryParse(input, out Height);
            IGameOfLife game = Factory.CreateGameOfLife(Width,Height);
            return game;
        }
        public static bool ReadFromaFile()
        {
            Messages.ReadFromaFileMessasge();
            string input = Console.ReadLine();
            Boolean.TryParse(input, out bool result);
            return result;
        }
        public static bool WriteToaFile()
        {
            Messages.WriteToaFileMessage();
            string input = Console.ReadLine();
            Boolean.TryParse(input, out bool result);
            return result;
        }
    }
}
