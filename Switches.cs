using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Switches
    {
        public static void MainSwitch(ref WorkingWithFiles file, ref List<IGameOfLife> games)
        {
            Messages.Option1();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.F1:
                    games = file.ReadFromaFile();
                    Messages.Option2(games);
                    SubSwitch1(games);
                    break;
                case ConsoleKey.F2:
                    games = new List<IGameOfLife>();
                    for (int i = 0; i < 1000; i++)
                    {
                        var randompattern = new RandomPattern();
                        IGameOfLife tempgame = new GameOfLife(10, 15);
                        randompattern.Add(tempgame);
                        games.Add(tempgame);
                    }
                    Messages.ThousandGameCreation();
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
        }
        public static void SubSwitch1(List<IGameOfLife> games)
        {
            var timer = new TimerGOL();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.F1:
                    Messages.Option3();
                    SubSwitch2(games);
                    break;
                case ConsoleKey.F2:
                    timer.StartTimer(games[0]);
                    break;
            }
        }
        public static void SubSwitch2(List<IGameOfLife> games)
        {
            var timer = new TimerGOL();
            List<IGameOfLife> ToIterate = new List<IGameOfLife>();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.F1:
                    for (int i = 0; i < 8; i++)
                    {
                        Messages.EnterGameNr(i);
                        Int32.TryParse(Console.ReadLine(), out int gamenr);
                        ToIterate.Add(games[gamenr]);
                    }
                    timer.StartTimer(games, ToIterate);
                    break;
                case ConsoleKey.F2:
                    for (int i = 0; i < 8; i++)
                    {
                        ToIterate.Add(games[i]);
                    }
                    timer.StartTimer(games, ToIterate);
                    break;
            }
        }
    }
}
