using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class TimerGOL
    {
        public void StartTimer(IGameOfLife game)
        {
            var Factory = new Factory();
            var timer = Factory.CreateTimer();
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
            var Factory = new Factory();
            var timer = Factory.CreateTimer();
            timer.Elapsed += (sender, e) => TimerTick(games,ToIterate);
            timer.Start();
            Console.Clear();
            GameOfLife.PrintMatrix(ToIterate);
            Console.WriteLine("Live game count :{0}", games.Count);
            Console.WriteLine("Alive cell count :{0}", GameOfLife.GetTotalCellCount(games));
            Messages.PressKeyToStopMessage();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();
            Messages.TerminatingApplicationMessage();
        }
        void TimerTick(List<IGameOfLife> games, List<IGameOfLife> ToIterate)
        {
            Console.Clear();
            foreach (var game in games)
            {
                game.Iterate();
            }
            GameOfLife.PrintMatrix(ToIterate);
            Console.WriteLine("Live game count :{0}", games.Count);
            Console.WriteLine("Alive cell count :{0}", GameOfLife.GetTotalCellCount(games));
            Messages.PressKeyToStopMessage();
        }
    }
}
