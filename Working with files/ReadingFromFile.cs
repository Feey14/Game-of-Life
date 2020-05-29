using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace GameOfLife
{
    class ReadingFromFile
    {
        public static List<IGameOfLife> ReadFromaFile()
        {
            List<IGameOfLife> games = new List<IGameOfLife>();
            Console.Clear();
            Console.WriteLine("Reading from a file");
            using (StreamReader sr = new StreamReader("../../../TestFile.txt"))
            {
                List<IGameOfLife> list = new List<IGameOfLife>();
                char[] delimiterChars = { ':' };
                String line = sr.ReadLine();
                string[] words = line.Split(delimiterChars);
                Int32.TryParse(words[1], out int Width);

                line = sr.ReadLine();
                words = line.Split(delimiterChars);
                Int32.TryParse(words[1], out int Height);
                IGameOfLife game = Factory.CreateGameOfLife(Width, Height);

                for (int i = 0; i < Height; i++) // i == Width
                {
                    line = sr.ReadLine();
                    char[] b = new char[line.Length];
                    for (int j = 0; j < Width; j++) // j == Height
                    {
                        if (b[j] == 'X') game.Matrix[j, i] = 1;

                    }
                }
                games.Add(game);
                game.PrintMatrix();
                return games;
            }
        }
    }
}
