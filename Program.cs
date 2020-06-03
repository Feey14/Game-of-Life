using System;
using System.Collections.Generic;
using System.Timers;

namespace GameOfLife
{
    class Program
    {
        static void Main()
        {
            List<IGameOfLife> thousndgames = Factory.CreateThousandGames();
            List<IGameOfLife> games = Factory.CreateListOfGameOfLife();
            Console.WriteLine("Press 'y' if you would like to read from a file!");
            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Y)
            {
                games = ReadingFromFile.ReadFromaFile();
                TimerGOL.StartTimer(games[1]);
                WriteToFile.WriteToaFile(games);
                Console.WriteLine("Reading from a file");
                foreach (var Game in games)
                {
                    Game.PrintMatrix();
                }
            }
            else
            {
                IGameOfLife game = UserInput.Capture();//initialazing game of life
                IGameOfLife game1 = UserInput.Capture();//initialazing game of life
                var lws = new LightWeightSpaceship();
                lws.Add(game);//Adding lightweightspaceship
                lws.Add(game1);//Adding lightweightspaceship
                TimerGOL.StartTimer(game);
                TimerGOL.StartTimer(game1);
                games.Add(game);
                games.Add(game1);
                WriteToFile.WriteToaFile(games);
            }
        }
    }
}