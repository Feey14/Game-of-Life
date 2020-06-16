using System;
using System.Collections.Generic;

namespace GameOfLife
{
    internal class Setup
    {
        public static List<IGameOfLife> CreateThousandGames()
        {
            List<IGameOfLife> games = new List<IGameOfLife>();
            for (int i = 0; i < 1000; i++)
            {
                var randompattern = new RandomPattern();
                IGameOfLife tempgame = new GameOfLife(30, 15);
                randompattern.Add(tempgame);
                games.Add(tempgame);
            }
            Messages.ThousandGameCreation();
            return games;
        }

        public static void SaveGames(List<IGameOfLife> games)
        {
            if (games.Count > 0)
            {
                Messages.SaveGames(games);
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    var file = new WorkingWithFiles();

                    file.WriteToaFile(games);
                    Console.Clear();
                    Messages.InformationIsSaved();
                }
            }
        }

        public static void DisplayEightGameOfLifeSetup(List<IGameOfLife> games)
        {
            List<IGameOfLife> toshow = new List<IGameOfLife>();
            UserInput userinput = new UserInput();
            var timer = new TimerGOL();

            userinput.CaptureGameOfLifes(games, toshow);
            timer.StartTimer(games, toshow);
        }

        public static void DisplayGameOfLifeSetup(List<IGameOfLife> games)
        {
            UserInput userinput = new UserInput();
            var timer = new TimerGOL();

            IGameOfLife game = userinput.CaptureGameNr(games);
            timer.StartTimer(game);
        }

        public static void CreateGameOfLifeSetup(List<IGameOfLife> games)
        {
            var UserInput = new UserInput();
            var timer = new TimerGOL();
            var lws = new LightWeightSpaceship();

            IGameOfLife game = UserInput.Capture();//initialazing game of life
            lws.Add(game);//Adding lightweightspaceship
            timer.StartTimer(game);
            games.Add(game);
        }
    }
}