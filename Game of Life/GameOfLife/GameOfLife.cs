using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    [Serializable]
    public class GameOfLife : IGameOfLife
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool[,] Matrix { get; set; }
        public int IterationCount { get; set; } = 0;
        public int AliveCells { get; set; } = 0;
        public GameOfLife(int Width, int Height) // Constructor class that creates Matrix
        {
            this.Width = Width;
            this.Height = Height;
            Matrix = new bool[Width, Height];
        }
        public void PrintMatrix()//Printing Matrix
        { 
            StringBuilder line = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                line.Clear();
                for (int x = 0; x < Width; x++)
                {
                    if (Matrix[x, y] == true) { line.Append("X"); }
                    else if (Matrix[x, y] == false) { line.Append(" "); }
                }
                Messages.PrintLine(line + "|");// Printing line and right border symbol
            }
            line.Clear();
            for (int x = 0; x <= Width; x++)// Printing bottom border
            {
                line.Append("-");
            }
            Messages.PrintLine(line.ToString()); // Wierd moment
            PrintInformation();
        }
        public int GetNeighbourCount(int x, int y)
        {
            int NeighbourCount = 0;
            for (int l = -1; l <= 1; l++)
                for (int m = -1; m <= 1; m++)
                {
                    if (x + l < 0 || y + m < 0 || x + l >= Width || y + m >= Height) continue;
                    else
                        NeighbourCount += Convert.ToInt32(Matrix[x + l, y + m]);
                }
            NeighbourCount -= Convert.ToInt32(Matrix[x, y]);
            return NeighbourCount;
        }
        public void Iterate()
        {
            List<Coordinates> ToAdd = new List<Coordinates>();
            List<Coordinates> ToRemove = new List<Coordinates>();
            for (int y = 0; y < Height; y++) // y == Height
            {
                for (int x = 0; x < Width; x++) // y == Width
                {
                    int NeighbourCount = GetNeighbourCount(x, y);
                    if (NeighbourCount == 3) // if neighbour count is 3 adding coordinates to List
                    {
                        Coordinates coord = new Coordinates(x, y);
                        ToAdd.Add(coord);
                    }
                    if (NeighbourCount == 0 || NeighbourCount == 1 || NeighbourCount >= 4)// if Cell is to be destroyed Add to ToRemove List
                    {
                        Coordinates coord = new Coordinates(x, y);
                        ToRemove.Add(coord);
                    }
                }
            }
            AddCells(ToAdd);
            RemoveCells(ToRemove);
            IterationCount++;
        }
        public void AddCells(List<Coordinates> ToAdd)
        {
            foreach (var add in ToAdd)// Adding new Cells
            {
                if (Matrix[add.WidthCoord, add.HeightCoord] == false)
                {
                AddCell(add.WidthCoord, add.HeightCoord); 
                }
            }
        }
        public void RemoveCells(List<Coordinates> ToRemove)
        {
            foreach (var add in ToRemove)// Deleting Cells
            {
                if(Matrix[add.WidthCoord, add.HeightCoord] == true)
                {
                    RemoveCell(add.WidthCoord, add.HeightCoord);
                }
            }
        }
        public void AddCell(int x, int y) // Adding cell to the matrix
        {
            if (x > Width - 1 || y > Height - 1)
                throw new IndexOutOfRangeException("Index was outside the bounds of the array");
            else
            {
                Matrix[x, y] = true;
                AliveCells++;
            }
        }
        public void RemoveCell(int x, int y) // Adding cell to the matrix
        {
            if (x > Width - 1 || y > Height - 1)
                throw new IndexOutOfRangeException("Index was outside the bounds of the array");
            else
            {
                Matrix[x, y] = false;
                AliveCells--;
            }
        }
        public void PrintInformation()
        {
            Messages.PrintCellCounnt(AliveCells);
            Messages.PrintIterationCount(IterationCount);
        }
        public static KeyValuePair<int,int> GetTotalCellCountAndActiveGameCount(List<IGameOfLife> games)
        {
            int activegamecount = games.Count;
            int totalcellcount = 0;
            foreach (var game in games)
            {
                totalcellcount += game.AliveCells;
                if (game.AliveCells == 0) activegamecount--;
            }
            return new KeyValuePair<int, int>(totalcellcount, activegamecount);
        }
        //wierd code below 
        //Print Matrix function that takes 8 games and prints them and when needed(when games cant fit in one line) it transfers to a new line
        public static void PrintMatrix(List<IGameOfLife> ToIterate)
        {
            List<string> lines = new List<string>();
            int linecount = 0;
            int consoleWidth = 210;
            int maxheight = 0;
            foreach (var game in ToIterate)
            {
                if (game.Height > maxheight) { maxheight = game.Height; }
            }
            for (int i = 0; i <= maxheight; i++)
            {
                StringBuilder line = new StringBuilder();
                foreach (var game in ToIterate)
                {
                    line = GetlineForPrinting(game, line, i);
                }
                lines.Add(line.ToString());
            }
            float division = (lines[0].Length / consoleWidth);
            linecount = (int)Math.Ceiling(division) + 1;
            if (linecount > 1)
            {
                List<string> linesarr = new List<string>();
                foreach (var line in lines)
                {
                    string templine = "";
                    if (line.Length > consoleWidth)
                    {
                        var minilines = line.Split('|');
                        templine = "";
                        linecount = 1;
                        foreach (var miniline in minilines)
                        {
                            if (templine.Length + miniline.Length < consoleWidth)
                            {
                                templine += miniline + "|";
                                continue;
                            }
                            linesarr.Add(templine);
                            templine = "";
                            templine += miniline + "|";
                            linecount++;
                        }
                    }
                    else
                    {
                        linesarr.Add(line);
                    }
                    linesarr.Add(templine);
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
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public static StringBuilder GetlineForPrinting(IGameOfLife game, StringBuilder line, int height)
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

    }
}