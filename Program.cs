using System;
using System.Collections.Generic;
using System.Timers;

namespace GameOfLife
{
    class Program
    {
        static void Main()
        {
            IGameOfLife game  = UserInput.Capture();//initialazing game of life
            var lws = new LightWeightSpaceship();
            lws.Add(game);//Adding lightweightspaceship
            TimerGOL.StartTimer(game);//Starting timer
            List<IGameOfLife> games = ReadingFromFile.ReadFromaFile();
            games.Add(game);
            WriteToFile.WriteToaFile(games);
            Console.ReadLine();
        }
    }
}