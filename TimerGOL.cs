using System;
using System.Collections.Generic;
using System.Timers;

namespace GameOfLife
{
    internal class TimerGOL
    {
        public void StartTimer(IGameOfLife game)
        {
            Timer timer = new Timer(1000);
            List<IGameOfLife> games = new List<IGameOfLife>() { game };

            timer.Elapsed += (sender, e) => TimerTick(games, games, games, 1);
            timer.Start();
            Console.Clear();
            game.PrintMatrix();
            Messages.PressKeyToStopMessage();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();
            Messages.TerminatingApplicationMessage();
        }

        public void StartTimer(List<IGameOfLife> games, List<IGameOfLife> ToIterate)// Timer for displaying 8 games
        {
            Timer timer = new Timer(1000);
            List<IGameOfLife> toshow = new List<IGameOfLife>();
            UserInput userinput = new UserInput();
            int state = 0;

            timer.Elapsed += (sender, e) => TimerTick(games, ToIterate, toshow, state);
            timer.Start();
            Console.Clear();
            PrintMultipleGames.PrintMatrix(ToIterate);
            Messages.GameCountAndCellCount(PrintMultipleGames.GameOfLifeStatistics(games));
            Messages.IterateOtherGames();
            if (Console.ReadKey().Key == ConsoleKey.F1) state = 2;
            else state = 1;
            if (state == 2)//Entering games thatwill be shown
            {
                userinput.CaptureGameOfLifes(games, toshow);
                timer.Stop();
                timer.Dispose();
                StartTimer(games, toshow);
            }
            else
                Messages.PressKeyToStopMessage();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();
        }

        private void TimerTick(List<IGameOfLife> games, List<IGameOfLife> ToIterate, List<IGameOfLife> toshow, int state)
        {
            Console.Clear();
            if (ToIterate.Count == 1)
            {
                Console.Clear();
                ToIterate[0].Iterate();
                ToIterate[0].PrintMatrix();
            }
            else
            {
                foreach (IGameOfLife game in games)
                {
                    if (game.AliveCells != 0)
                    {
                        game.Iterate();
                    }
                }
                PrintMultipleGames.PrintMatrix(ToIterate);
                Messages.GameCountAndCellCount(PrintMultipleGames.GameOfLifeStatistics(games));
            }
            if (state == 2)//Entering games
                Messages.EnterGameNr(toshow.Count + 1);
            else if (state == 1)//Stopping
                Messages.PressKeyToStopMessage();
            else if (state == 0)//Checking if user wants to enter other games
                Messages.IterateOtherGames();
        }
    }
}