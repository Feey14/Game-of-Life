using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace GameOfLife
{
    class TimerGOL
    {
        public static void StartTimer(GameOfLife game)
        {
            var timer = new Timer(1000);
            timer.Elapsed += (sender, e) => MyElapsedMethod(game);
            timer.Start();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();
            Console.WriteLine("Terminating the application...");
        }
        static void MyElapsedMethod(GameOfLife game)
        {
            Console.Clear();
            game.PrintMatrix();
            game.Iterate();
            Console.WriteLine("Press any key to stop");
        }
    }
}
