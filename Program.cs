using System;
using System.Collections.Generic;
using System.Timers;

namespace GameOfLife
{
    class Program
    {
        static void Main()
        {
            if (UserInput.ReadFromaFile())
            {
                List<IGameOfLife> games = ReadingFromFile.ReadFromaFile();
                foreach(var game in games)
                {
                    TimerGOL.StartTimer(game);
                }
                WriteToFile.WriteToaFile(games);
                if (UserInput.WriteToaFile()) WriteToFile.WriteToaFile(games);
            }
            else {
                IGameOfLife game = UserInput.Capture();//initialazing game of life
                var lws = new LightWeightSpaceship();
                lws.Add(game);//Adding lightweightspaceship
                TimerGOL.StartTimer(game);//Starting
                if (UserInput.WriteToaFile()) WriteToFile.WriteToaFile(game);
            }
            Console.ReadLine();
        }
    }
}