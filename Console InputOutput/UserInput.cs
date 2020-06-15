using System;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    class UserInput
    {
        public IGameOfLife Capture()
        {
        Messages.WidthInputMessage();
        string input = Console.ReadLine();
        bool parse1 = Int32.TryParse(input, out int Width);
        Messages.HeightInputMessage();
        input = Console.ReadLine();
        bool parse2 = Int32.TryParse(input, out int Height);
        while (Height<0 || Width<0 || Width>210 || !parse1 || !parse2)
        {
            Messages.EnterValidNumbers();
            Messages.WidthInputMessage();
            input = Console.ReadLine();
            parse1 = Int32.TryParse(input, out Width);
            Messages.HeightInputMessage();
            input = Console.ReadLine();
            parse2 = Int32.TryParse(input, out Height);
        }
            IGameOfLife game = new GameOfLife(Width,Height);
            return game;
        }
        public void CaptureGameOfLifes(List<IGameOfLife> games, List<IGameOfLife> toshow)
        {
            while (toshow.Count < 8)
            {
                Messages.EnterGameNr(toshow.Count + 1);
                string input = Console.ReadLine();
                bool parsing = Int32.TryParse(input, out int gameNr);
                while (gameNr >= games.Count || gameNr<0 || !parsing)
                {
                    Messages.EnterValidNumbers();
                    Messages.EnterGameNr(toshow.Count + 1);
                    input = Console.ReadLine();
                    parsing = Int32.TryParse(input, out gameNr);
                }
                toshow.Add(games[gameNr]);
            }
        }
    }
}
