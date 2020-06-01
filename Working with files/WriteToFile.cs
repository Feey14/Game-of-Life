using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GameOfLife
{
    class WriteToFile
    {
        public static void WriteToaFile(List<IGameOfLife> games)
        {
            using (StreamWriter outputFile = new StreamWriter("../../../TestFile.txt", false))
            {
                foreach (var game in games)
                {
                    outputFile.WriteLine("Matrix Width : {0}", game.Width);
                    outputFile.WriteLine("Matrix Height : {0}", game.Height);
                    string line;
                    for (int i = 0; i < game.Height; i++)
                    {
                        line = "";
                        for (int j = 0; j < game.Width; j++)
                        {
                            if (game.Matrix[j, i] == 1) { line += "X"; }
                            else if (game.Matrix[j, i] == 0) { line += " "; }
                        }
                        outputFile.WriteLine(line);// Printing line and right border symbol
                    }
                    outputFile.WriteLine("Alive Cell Count:{0}", game.AliveCells);
                    outputFile.WriteLine("Iteration count:{0}", game.IterationCount);
                }
            }
        }
    }
}
