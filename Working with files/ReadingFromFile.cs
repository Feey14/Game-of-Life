using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;

namespace GameOfLife
{
    class ReadingFromFile
    {
        public static List<IGameOfLife> ReadFromaFile()
        {
            List<IGameOfLife> games = Factory.CreateListOfGameOfLife();
            Console.Clear();
            Console.WriteLine("Reading from a file");
            using (StreamReader sr = new StreamReader("../../../TestFile.txt"))
            {
                String line;
                while ((line = sr.ReadLine()) != null) 
                {
                    List<IGameOfLife> list = new List<IGameOfLife>();
                    char[] delimiterChars = { ':' };
                    string[] words = line.Split(delimiterChars);
                    Int32.TryParse(words[1], out int Width);

                    line = sr.ReadLine();//Reading Height 
                    words = line.Split(delimiterChars);
                    Int32.TryParse(words[1], out int Height);
                    IGameOfLife game = Factory.CreateGameOfLife(Width, Height);

                    for (int i = 0; i < Height; i++) // i == Width
                    {
                        line = sr.ReadLine();
                        for (int j = 0; j < Width; j++) // j == Height
                        {
                            if (line[j] == 'X') game.Matrix[j, i] = 1;
                        }
                    }
                    line = sr.ReadLine();//Reading Alive cells line
                    words = line.Split(delimiterChars);
                    Int32.TryParse(words[1], out int alivecells);
                    game.AliveCells = alivecells;

                    line = sr.ReadLine();//Reading iteration count line
                    words = line.Split(delimiterChars);
                    Int32.TryParse(words[1], out int iterations);
                    game.IterationCount = iterations;

                    games.Add(game);
                    game.PrintMatrix();
                }
                return games;
            }
        }
    }
}
