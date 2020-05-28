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
            Console.WriteLine("Terminating the application...");
        }
        static void MyElapsedMethod(IGameOfLife game)
        {
            Console.Clear();
            game.PrintMatrix();
            game.Iterate();
            Console.WriteLine("Press any key to stop");
        }
    }
}
