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
                var file = new WorkingWithFiles();
                List<IGameOfLife> games = new List<IGameOfLife>();
                var timer = new TimerGOL();
                Messages.Option1();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.F1:
                        games = file.ReadFromaFile();
                        Messages.Option2(games);
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.F1:
                                Messages.Option3();
                                List<IGameOfLife> ToIterate = new List<IGameOfLife>();
                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.F1:
                                        for (int i = 0; i < 8; i++)
                                        {
                                            ToIterate.Add(games[i]);
                                        }
                                        timer.StartTimer(games, ToIterate);
                                        break;
                                    case ConsoleKey.F2:
                                        for (int i = 0; i < 8; i++)
                                        {
                                            Messages.EnterGameNr(i);
                                            Int32.TryParse(Console.ReadLine(), out int gameNr);
                                            ToIterate.Add(games[gameNr]);
                                        }
                                        timer.StartTimer(games, ToIterate);
                                        break;
                                }
                                break;
                            case ConsoleKey.F2:
                                timer.StartTimer(games[0]);
                                break;
                        }
                        break;
                    case ConsoleKey.F2:
                        games = new List<IGameOfLife>();
                        for (int i = 0; i < 1000; i++)
                        {
                            var randompattern = new RandomPattern();
                            IGameOfLife tempgame = new GameOfLife(30, 15);
                            randompattern.Add(tempgame);
                            games.Add(tempgame);
                        }
                        Messages.ThousandGameCreation();
                        break;
                    case ConsoleKey.F3:
                        var UserInput = new UserInput();
                        IGameOfLife game = UserInput.Capture();//initialazing game of life
                        var lws = new LightWeightSpaceship();
                        lws.Add(game);//Adding lightweightspaceship
                        timer.StartTimer(game);
                        games.Add(game);
                        file.WriteToaFile(games);
                        break;
                }
                Messages.SaveGames(games);
                if (Console.ReadKey().Key == ConsoleKey.Y && games.Count>0)
                {
                    file.WriteToaFile(games);
                    Console.Clear();
                    Messages.InformationIsSaved();
                }
                Messages.EndOfProgram();
                if (!(Console.ReadKey().Key == ConsoleKey.Y)) repeat = false;
            } while (repeat == true);
        }
    }
}