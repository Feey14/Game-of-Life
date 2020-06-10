using System;
using System.Collections.Generic;
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
            GetAliveCellCount();
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
            for (int y = 0; y < Height; y++) // i == Width
            {
                for (int x = 0; x < Width; x++) // j == Height
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
            GetAliveCellCount();
            IterationCount++;
        }
        public void AddCells(List<Coordinates> ToAdd)
        {
            foreach (var add in ToAdd)// Adding new Cells
            {
                AddCell(add.WidthCoord, add.HeightCoord);
            }
        }
        public void RemoveCells(List<Coordinates> ToRemove)
        {
            foreach (var add in ToRemove)// Deleting Cells
            {
                RemoveCell(add.WidthCoord, add.HeightCoord);
            }
        }
        public void AddCell(int x, int y) // Adding cell to the matrix
        {
            if (x > Width - 1 || y > Height - 1)
                throw new System.IndexOutOfRangeException("Index was outside the bounds of the array");
            else
                Matrix[x, y] = true;
        }
        public void RemoveCell(int x, int y) // Adding cell to the matrix
        {
            if (x > Width - 1 || y > Height - 1)
                throw new System.IndexOutOfRangeException("Index was outside the bounds of the array");
            else
                Matrix[x, y] = false;
        }
        public void GetAliveCellCount()
        {
            AliveCells = 0;
            for (int x = 0; x < Width; x++) // i == Width
            {
                for (int y = 0; y < Height; y++) // j == Height
                {
                    if (Matrix[x, y] == true) AliveCells++;
                }
            }
        }
        public void PrintInformation()
        {
            Messages.PrintCellCounnt(AliveCells);
            Messages.PrintIterationCount(IterationCount);
        }
        public static int GetTotalCellCount(List<IGameOfLife> games)
        {
            int cellcount = 0;
            foreach (var game in games)
            {
                game.GetAliveCellCount();
                cellcount += game.AliveCells;
            }
            return cellcount;
        }
        //wierd code below 
        //Print Matrix function that takes 8 games and prints them and when needed(when games cant fit in one line) it transfers to a new line
        public static void PrintMatrix(List<IGameOfLife> ToIterate)
        {
            List<StringBuilder> lines = new List<StringBuilder>();
            int linecount;
            int consoleWidth = 110;
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
                lines.Add(line);
            }
            float division = (lines[0].Length / consoleWidth);
            linecount = (int)Math.Ceiling(division) + 1;
            if (linecount > 1)
            {
                List<StringBuilder> linesarr = new List<StringBuilder>();
                foreach (var line in lines)
                {
                    StringBuilder templine = new StringBuilder();
                    if (line.Length > consoleWidth)
                    {
                        var minilines = line.ToString().Split('|');
                        templine.Clear();
                        linecount = 1;
                        foreach (var miniline in minilines)
                        {
                            if (templine.Length + miniline.Length < consoleWidth)
                            {
                                templine.Append( miniline + "|");
                                continue;
                            }
                            linesarr.Add(templine);
                            templine.Clear();
                            templine.Append( miniline + "|" );
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