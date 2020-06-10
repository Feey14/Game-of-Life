using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main()
        {
            bool repeat = true;
            do
            {
                var file = new WorkingWithFiles();
                List<IGameOfLife> games = new List<IGameOfLife>();
                Switches.MainSwitch(ref file,ref games);
                Messages.SaveGames(games);
                if (Console.ReadKey().Key == ConsoleKey.Y && games.Count>0)
                {
                    file.WriteToaFile(games);
                    Console.Clear();
                    Messages.InformationIsSaved();
                }
                Messages.EndOfProgram();
                if (!(Console.ReadKey().Key == ConsoleKey.Y)) repeat = false;
            } while (repeat == true);
        }
    }
}