using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main()
        {
            bool repeat = true;
            do
            {
                var Factory = new Factory();
                var file = new WorkingWithFiles();
                List<IGameOfLife> games = Factory.CreateListOfGameOfLife();
                Console.Clear();
                Console.WriteLine("Press F1 if you would like to read from a file");
                Console.WriteLine("Press F2 if you would like to create 1000 games");
                Console.WriteLine("Press F3 if you would like to create one Game of Life");
                switch (Console.ReadKey().Key)
                {
                case ConsoleKey.F1:
                    games = file.ReadFromaFile();
                    Console.WriteLine("Item count in list : {0} ", games.Count);
                    Console.WriteLine("Press 'F1' if you would like to display 8 games");
                    Console.WriteLine("Press 'F2' if you would like to display 1 game");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.F1:
                            var timer1 = new TimerGOL();
                            timer1.StartTimer(games, games[1], games[2], games[3], games[4], games[5], games[6], games[7], games[8]);
                            break;
                        case ConsoleKey.F2:
                            var timer2 = new TimerGOL();
                            timer2.StartTimer(games[0]);
                            break;
                    }
                    break;
                case ConsoleKey.F2:
                    games = Factory.CreateThousandGames();
                    break;
                case ConsoleKey.F3:
                    var timer = new TimerGOL();
                    var UserInput = new UserInput();
                    IGameOfLife game = UserInput.Capture();//initialazing game of life
                    var lws = new LightWeightSpaceship();
                    lws.Add(game);//Adding lightweightspaceship
                    timer.StartTimer(game);
                    games.Add(game);
                    file.WriteToaFile(games);
                    break;
                }
                Console.WriteLine("Press 'y' if you would like to save to a file");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    file.WriteToaFile(games);
                }
                Console.WriteLine("Press 'y' if you would like to repeat programm");
                if (!(Console.ReadKey().Key == ConsoleKey.Y)) repeat = false;
            } while (repeat == true);
        }
    }
}