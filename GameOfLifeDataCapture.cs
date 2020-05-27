﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class GameOfLifeDataCapture
    {
        public static GameOfLife Capture()
        {
            int Width;
            Console.WriteLine("Enter Matrix Width");
            string input = Console.ReadLine();
            Int32.TryParse(input, out Width);
            Console.Clear();

            int Height;
            Console.WriteLine("Enter Matrix Width");
            input = Console.ReadLine();
            Int32.TryParse(input, out Height);
            Console.Clear();
            var game = new GameOfLife(Width, Height);
            return game;
        }
    }
}