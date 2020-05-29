using System;
using System.Timers;

namespace GameOfLife
{
    class Program
    {
        static void Main()
        {
            IGameOfLife game  = UserInput.Capture();//initialazing GOL

            var lws = new LightWeightSpaceship();

            lws.Add(game);//Adding cells

            TimerGOL.StartTimer(game);//Starting timer

            WriteToFile.WriteToFilea(game);
            //ReadingFromFile.ReadFromaFile();
            //Console.ReadLine();
        }
    }
}