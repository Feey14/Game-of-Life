using System;

namespace GameOfLife
{
    class UserInput
    {
        public IGameOfLife Capture()
        {
            var Factory = new Factory();
            Messages.WidthInputMessage();
            string input = Console.ReadLine();
            Int32.TryParse(input, out int Width);

            Messages.HeightInputMessage();
            input = Console.ReadLine();
            Int32.TryParse(input, out int Height);
            IGameOfLife game = Factory.CreateGameOfLife(Width,Height);
            return game;
        }
    }
}
