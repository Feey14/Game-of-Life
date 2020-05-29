using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace GameOfLife
{
    class TimerGOL
    {
        public static void StartTimer(IGameOfLife game)
        {
            var timer = Factory.CreateTimer();
            timer.Elapsed += (sender, e) => MyElapsedMethod(game);
            timer.Start();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();
            Messages.TerminatingApplicationMessage();
        }
        static void MyElapsedMethod(IGameOfLife game)
        {
            Console.Clear();
            game.PrintMatrix();
            game.GetAliveCellCount();
            game.PrintInformation();
            game.Iterate();
            Messages.PressKeyToStopMessage();
        }
    }
}
