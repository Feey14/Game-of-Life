using System;
using System.Collections.Generic;
using System.IO;

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
                    if (File.Exists("../../../TestFile.bin"))
                    {
                        games = file.ReadFromaFile();
                        Messages.Option2(games);
                    }
                    else
                    {
                        Messages.FileDoesNotExist();
                        break;
                    }
                        switch (Console.ReadKey().Key)
                        {
                        case ConsoleKey.F1:
                            Messages.Option3();
                            List<IGameOfLife> ToIterate = new List<IGameOfLife>();
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.F1:
                                        if (games.Count > 8)
                                        {
                                            for (int i = 0; i < 8; i++)
                                            {
                                                ToIterate.Add(games[i]);
                                            }
                                        }
                                        else
                                        {
                                            Messages.NotEnoughGames();
                                            break;
                                        }
                                    timer.StartTimer(games, ToIterate);
                                    break;
                                case ConsoleKey.F2:
                                    UserInput userinput = new UserInput();
                                    List<IGameOfLife> toshow = new List<IGameOfLife>();
                                    userinput.CaptureGameOfLifes(games, toshow);
                                    timer.StartTimer(games, toshow);
                                    break;
                            }
                            break;
                        case ConsoleKey.F2:
                        if (games.Count > 1)
                        {
                            timer.StartTimer(games[0]);
                        }
                        else
                        {
                            Messages.NotEnoughGames();
                            break;
                        }
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
                if (games.Count > 0)
                {
                    Messages.SaveGames(games);
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Messages.SaveGames(games);
                        file.WriteToaFile(games);
                        Console.Clear();
                        Messages.InformationIsSaved();
                    }
                }
                Messages.EndOfProgram();
                if (!(Console.ReadKey().Key == ConsoleKey.Y)) repeat = false;
            } while (repeat == true);
        }
    }
}