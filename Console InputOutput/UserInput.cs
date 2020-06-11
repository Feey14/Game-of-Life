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
            Int32.TryParse(input, out int Width);

            Messages.HeightInputMessage();
            input = Console.ReadLine();
            Int32.TryParse(input, out int Height);
            IGameOfLife game = new GameOfLife(Width,Height);
            return game;
        }
        public void CaptureGameOfLifes(List<IGameOfLife> games)
        {
            List<IGameOfLife> toshow = new List<IGameOfLife>();
            TimerGOL timer = new TimerGOL();
            timer.StartTimer(games, toshow);
        }
        public List<IGameOfLife> CaptureGameOfLifes1(List<IGameOfLife> games, List<IGameOfLife> toshow)
        {
            while (toshow.Count < 8)
            {
                Messages.EnterGameNr(toshow.Count + 1);
                var input = Console.ReadLine();
                Int32.TryParse(input, out int gameNr);
                toshow.Add(games[gameNr]);
            }
            return toshow;
        }
    }
}
