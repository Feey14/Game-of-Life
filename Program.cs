using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks.Sources;
using System.Timers;

namespace GameOfLife
{
    class Program
    {
        static void Main()
        {
            bool repeat=true;
            do
            {
                var Factory = new Factory();
                var file = new WorkingWithFiles();

                List<IGameOfLife> games = Factory.CreateListOfGameOfLife();

                Console.WriteLine("Press 'y' if you would like to read from a file!");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    games = file.ReadFromaFile();
                    Console.WriteLine("Item count in list : {0} ", games.Count);
                    Console.WriteLine("Press 'y' if you would like to display 8 windows");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        var timer = new TimerGOL();
                        timer.StartTimer(games, games[1], games[2], games[3], games[4], games[5], games[6], games[7], games[8]);
                    }
                    else
                    {
                        var timer = new TimerGOL();
                        timer.StartTimer(games[0]);
                    }
                }
                else
                {
                    Console.WriteLine("Press 'y' if you would like to create 1000 games. Press any other key to create single game");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        games = Factory.CreateThousandGames();
                    }
                    else
                    {
                        var timer = new TimerGOL();
                        var UserInput = new UserInput();
                        IGameOfLife game = UserInput.Capture();//initialazing game of life
                        var lws = new LightWeightSpaceship();
                        lws.Add(game);//Adding lightweightspaceship
                        timer.StartTimer(game);
                        games.Add(game);
                        file.WriteToaFile(games);
                    }
                }
                Console.WriteLine("Press 'y' if you would like to save to a file");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    file.WriteToaFile(games);
                }
                Console.WriteLine("Press 'y' if you would like to end programm");
                if (!(Console.ReadKey().Key == ConsoleKey.Y)) repeat = false;
            } while (repeat == false);
        }
    }
}