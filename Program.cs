using System;
using System.Timers;

namespace GameOfLife
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


            var timer = new Timer(1000);
            timer.Elapsed += (sender, e) => MyElapsedMethod(sender, e, game);
            timer.Start();
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();

            Console.WriteLine("Terminating the application...");
        }
        static void MyElapsedMethod(object sender, ElapsedEventArgs e, GameOfLife game)
        {
            Console.Clear();
            game.PrintMatrix();
            game.Iterate();
            Console.WriteLine("Press any key to stop");
        }
    }
}