using System;
using System.Timers;

namespace GameOfLife
{
    class Program
    {
        static void Main()
        {

            GameOfLife game  = GameOfLifeDataCapture.Capture();

            Patterns.LightWeightSpaceship(game);

            TimerGOL.StartTimer(game);
        }
    }
}