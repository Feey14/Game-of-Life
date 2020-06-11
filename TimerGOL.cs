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
            var timer = new Timer(3000);
            List<IGameOfLife> toshow = new List<IGameOfLife>();
            UserInput userinput = new UserInput();
            timer.Elapsed += (sender, e) => TimerTick(games, ToIterate, toshow, userinput);
            timer.Start();
            Console.Clear();
            GameOfLife.PrintMatrix(ToIterate);
            Messages.GameCountAndCellCount(games);
            if (toshow.Count != 8) userinput.CaptureGameOfLifes1(games, toshow);
            if (toshow.Count == 8)
            {
                timer.Stop();
                timer.Dispose();
                StartTimer(games,toshow);
            }
            Messages.PressKeyToStopMessage();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();
            Messages.TerminatingApplicationMessage();
        }
        void TimerTick(List<IGameOfLife> games, List<IGameOfLife> ToIterate, List<IGameOfLife> toshow, UserInput userinput)
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
            Messages.EnterGameNr(toshow.Count+1);
            Messages.PressKeyToStopMessage();
        }
    }
}
