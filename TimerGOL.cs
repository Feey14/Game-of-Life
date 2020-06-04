using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Xml.Schema;

namespace GameOfLife
{
    class TimerGOL
    {
        public void StartTimer(IGameOfLife game)
        {
            var Factory = new Factory();
            var timer = Factory.CreateTimer();
            timer.Elapsed += (sender, e) => MyElapsedMethod(game);
            timer.Start();
            Console.Clear();
            game.PrintMatrix();
            Messages.PressKeyToStopMessage();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();
            Messages.TerminatingApplicationMessage();
        }
        void MyElapsedMethod(IGameOfLife game)
        {
            Console.Clear();
            game.Iterate();
            game.PrintMatrix();
            Messages.PressKeyToStopMessage();
        }
        public void StartTimer(List<IGameOfLife> games)
        {
            var Factory = new Factory();
            var timer = Factory.CreateTimer();
            timer.Elapsed += (sender, e) => MyElapsedMethod(games);
            timer.Start();
            Messages.PressKeyToStopMessage();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();
            Messages.TerminatingApplicationMessage();
        }
        void MyElapsedMethod(List<IGameOfLife> games)
        {
            Console.Clear();
            foreach (var game in games)
            {
                game.Iterate();
            }
            Messages.PressKeyToStopMessage();
        }
        public void StartTimer(List<IGameOfLife> games, IGameOfLife g1, IGameOfLife g2, IGameOfLife g3, IGameOfLife g4, IGameOfLife g5, IGameOfLife g6, IGameOfLife g7, IGameOfLife g8)
        {
            var Factory = new Factory();
            var timer = Factory.CreateTimer();
            timer.Elapsed += (sender, e) => MyElapsedMethod(games,g1,g2,g3,g4,g5,g6,g7,g8);
            timer.Start();
            Console.Clear();
            GameOfLife.PrintMatrix(g1, g2, g3, g4, g5, g6, g7, g8);
            Console.WriteLine("Live game count :{0}", games.Count);
            int cellcount = 0;
            foreach (var game in games)
            {
                cellcount += game.AliveCells;
            }
            Console.WriteLine("Live cell count :{0}", cellcount);
            Messages.PressKeyToStopMessage();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();
            Messages.TerminatingApplicationMessage();
        }
        void MyElapsedMethod(List<IGameOfLife> games, IGameOfLife g1, IGameOfLife g2, IGameOfLife g3, IGameOfLife g4, IGameOfLife g5, IGameOfLife g6, IGameOfLife g7, IGameOfLife g8)
        {
            Console.Clear();
            foreach (var game in games)
            {
                game.Iterate();
            }
            GameOfLife.PrintMatrix(g1, g2, g3, g4, g5, g6, g7, g8);
            Console.WriteLine("Live game count :{0}", games.Count);
            int cellcount = 0;
            foreach (var game in games)
            {
                cellcount += game.AliveCells;
            }
            Console.WriteLine("Live cell count :{0}", cellcount);
            Messages.PressKeyToStopMessage();
        }
    }
}
