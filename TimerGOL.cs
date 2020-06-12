using System;
using System.Collections.Generic;
using System.Timers;

namespace GameOfLife
{
    class TimerGOL
    {
        public void StartTimer(IGameOfLife game)
        {
            var timer = new Timer(1000);
            timer.Elapsed += (sender, e) => TimerTick(game);
            timer.Start();
            Console.Clear();
            game.PrintMatrix();
            Messages.PressKeyToStopMessage();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();
            Messages.TerminatingApplicationMessage();
        }
        void TimerTick(IGameOfLife game)
        {
            Console.Clear();
            game.Iterate();
            game.PrintMatrix();
            Messages.PressKeyToStopMessage();
        }
        public void StartTimer(List<IGameOfLife> games, List<IGameOfLife> ToIterate)// Timer for displaying 8 games
        {
            var timer = new Timer(1000);
            List<IGameOfLife> toshow = new List<IGameOfLife>();
            UserInput userinput = new UserInput();
            int state = 0;
            timer.Elapsed += (sender, e) => TimerTick(games, ToIterate, toshow, state);
            timer.Start();
            Console.Clear();
            GameOfLife.PrintMatrix(ToIterate);
            Messages.GameCountAndCellCount(games);
            Messages.IterateOtherGames();
            if (Console.ReadKey().Key == ConsoleKey.F1) state = 2;
            else state = 1;
            if (state == 2)
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
            Messages.TerminatingApplicationMessage();
        }
        void TimerTick(List<IGameOfLife> games, List<IGameOfLife> ToIterate, List<IGameOfLife> toshow, int state)
        {
            Console.Clear();
            foreach (var game in games)
            {
                if (game.AliveCells != 0)
                {
                    game.Iterate();
                }
            }
            GameOfLife.PrintMatrix(ToIterate);
            Messages.GameCountAndCellCount(games);
            if (state == 2)
                Messages.EnterGameNr(toshow.Count + 1);
            else if (state == 1)
                Messages.PressKeyToStopMessage();
            else if (state == 0)
                Messages.IterateOtherGames();

        }
    }
}
