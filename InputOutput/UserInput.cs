using System;
using System.Collections.Generic;

namespace GameOfLife
{
    internal class UserInput
    {
        public IGameOfLife Capture()//Captures Game of Life with max width of 210(fullscreen console)
        {
            int width, height;
            bool widthparse, heightparse;
            do
            {
                Messages.WidthInputMessage();
                string input = Console.ReadLine();
                widthparse = Int32.TryParse(input, out width);
                Messages.HeightInputMessage();
                input = Console.ReadLine();
                heightparse = Int32.TryParse(input, out height);
                if (height < 0 || width < 0 || width > 210 || !widthparse || !heightparse) Messages.EnterValidNumbers();
            } while (height < 0 || width < 0 || width > 210 || !widthparse || !heightparse);
            IGameOfLife game = new GameOfLife(width, height);
            return game;
        }

        public void CaptureGameOfLifes(List<IGameOfLife> games, List<IGameOfLife> toshow)//Captures eight games and adds it to toshow List
        {
            while (toshow.Count < 8)
            {
                bool gameNrparse;
                int gameNr;
                do
                {
                    Messages.EnterGameNr(toshow.Count + 1);
                    gameNrparse = Int32.TryParse(Console.ReadLine(), out gameNr);
                    if (gameNr >= games.Count || gameNr < 0 || !gameNrparse) Messages.EnterValidNumbers();
                } while (gameNr >= games.Count || gameNr < 0 || !gameNrparse);
                toshow.Add(games[gameNr]);
            }
        }

        public IGameOfLife CaptureGameNr(List<IGameOfLife> games)//Captures which game should be displayed and returns this game
        {
            bool parsing;
            int gameNr;
            do
            {
                Messages.EnterGameNr(1);
                parsing = Int32.TryParse(Console.ReadLine(), out gameNr);
                if (gameNr >= games.Count || gameNr < 0 || !parsing) Messages.EnterValidNumbers();
            } while (gameNr >= games.Count || gameNr < 0 || !parsing);
            return games[gameNr];
        }
    }
}