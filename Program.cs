using System;
using System.Collections.Generic;

namespace Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {

            int Width;
            int Height;


            Console.WriteLine("Enter Matrix Width");
            string input = Console.ReadLine();
            Int32.TryParse(input, out Width);
            Console.WriteLine("Enter Matrix Height");
            input = Console.ReadLine();
            Int32.TryParse(input, out Height);
            Console.Clear();

            var game = new GameOfLife(Width, Height);
     
            //Light-weightspaceship
            game.AddCell(11, 11);
            game.AddCell(14, 11);
            game.AddCell(15, 12);
            game.AddCell(11, 13);
            game.AddCell(15, 13);
            game.AddCell(12, 14);
            game.AddCell(13, 14);
            game.AddCell(14, 14);
            game.AddCell(15, 14);
     
            bool finished = false;
            while (finished == false)
            {
                game.PrintMatrix();
                game.iterate();
                Console.WriteLine("Write 1 to stop, Press Enter for next iteration");
                string stop;
                stop = Console.ReadLine();
                if (stop == "1") finished = true;
                else Console.Clear();
            }
            
        }
    }
}
