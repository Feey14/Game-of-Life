using System;

namespace GameOfLife
{
    class UserInput
    {
        public IGameOfLife Capture()
        {
            Messages.WidthInputMessage();
            string input = Console.ReadLine();
            Int32.TryParse(input, out int Width);

            Messages.HeightInputMessage();
            input = Console.ReadLine();
            Int32.TryParse(input, out int Height);
            IGameOfLife game = new GameOfLife(Width,Height);
            return game;
        }
    }
}
