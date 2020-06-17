using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class PrintMultipleGames
    {
        public static void PrintMatrix(List<IGameOfLife> ToIterate)//Splits strings so that they will fit evenly in console and prints games
        {
            List<string> lines = new List<string>();
            int consoleWidth = Console.WindowWidth;
            int maxheight = 0;
            foreach (IGameOfLife game in ToIterate)
            {
                if (game.Height > maxheight) { maxheight = game.Height; }
            }
            for (int i = 0; i <= maxheight; i++)
            {
                StringBuilder line = new StringBuilder();
                foreach (IGameOfLife game in ToIterate)
                {
                    line = GetlineForPrinting(game, line, i);
                }
                lines.Add(line.ToString());
            }
            float division = (lines[0].Length / consoleWidth);
            int linecount = (int)Math.Ceiling(division) + 1;
            if (linecount > 1)
            {
                List<string> linesarr = new List<string>();
                foreach (string line in lines)
                {
                    StringBuilder templine = new StringBuilder("");
                    if (line.Length > consoleWidth)
                    {
                        string[] minilines = line.Split('|');
                        templine.Clear();
                        linecount = 1;
                        foreach (string miniline in minilines)
                        {
                            if (templine.Length + miniline.Length < consoleWidth)
                            {
                                templine.Append(miniline).Append("|");
                                continue;
                            }
                            linesarr.Add(templine.ToString());
                            templine.Clear();
                            templine.Append(miniline).Append("|");
                            linecount++;
                        }
                    }
                    else
                    {
                        linesarr.Add(line);
                    }
                    linesarr.Add(templine.ToString());
                }
                for (int i = 0; i < linecount; i++)
                {
                    for (int j = 0; j <= maxheight; j++)
                    {
                        Console.WriteLine(linesarr[j * linecount + i]);
                    }
                }
            }
            else
            {
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public static StringBuilder GetlineForPrinting(IGameOfLife game, StringBuilder line, int height)//Creates concatenated string of all games
        {
            if (height > game.Height)
            {
                for (int j = 0; j < game.Width; j++)
                {
                    line.Append(" ");
                }
            }
            if (height == game.Height)
            {
                for (int j = 0; j < game.Width; j++)
                {
                    line.Append("-");
                }
                line.Append("|");
            }
            else
            {
                for (int j = 0; j < game.Width; j++)
                {
                    if (game.Matrix[j, height] == true) { line.Append("X"); }
                    else if (game.Matrix[j, height] == false) { line.Append(" "); }
                }
                line.Append("|");
            }
            return line;
        }

        public static Tuple<int, int> GameOfLifeStatistics(List<IGameOfLife> games)// Statistics of every game of life
        {
            int activegamecount = games.Count;
            int totalcellcount = 0;
            foreach (IGameOfLife game in games)
            {
                totalcellcount += game.AliveCells;
                if (game.AliveCells == 0) activegamecount--;
            }
            return new Tuple<int, int>(totalcellcount, activegamecount);
        }
    }
}