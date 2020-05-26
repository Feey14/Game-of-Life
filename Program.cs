using System;
using System.Collections.Generic;

namespace Game_Of_Life
{
    class Program
    {
        static void Main()
        {

            int Width,Height;

            Console.WriteLine("Enter Matrix Width");
            string input = Console.ReadLine();
            Int32.TryParse(input, out Width);
            Console.WriteLine("Enter Matrix Height");
            input = Console.ReadLine();
            Int32.TryParse(input, out Height);
            Console.Clear();

            var game = new GameOfLife(Width, Height);
     
            //glider
            game.AddCell(11, 10);
            game.AddCell(12, 11);
            game.AddCell(10, 12);
            game.AddCell(11, 12);
            game.AddCell(12, 12);

            bool finished = false;
            while (finished == false)
            {
                game.PrintMatrix();
                game.Iterate();
                Console.WriteLine("Write 1 to stop, Press Enter for next iteration");
                string stop;
                stop = Console.ReadLine();
                if (stop == "1") finished = true;
                else Console.Clear();
            }  
        }
    }
}
