using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
namespace GameOfLife
{
    [Serializable]
    public class GameOfLife : IGameOfLife
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int[,] Matrix { get; set; }
        public int IterationCount { get; set; } = 0;
        public int AliveCells { get; set; } = 0;
        public GameOfLife(int Width, int Height) // Constructor class that creates Matrix
        {
            this.Width = Width;
            this.Height = Height;
            Matrix = new int[Width, Height];
        }
        public void PrintMatrix()//Printing Matrix
        {
            GetAliveCellCount();
            string line;
            for (int i = 0; i < Height; i++)
            {
                line = "";
                for (int j = 0; j < Width; j++)
                {
                    if (Matrix[j, i] == 1) { line += "X"; }
                    else if (Matrix[j, i] == 0) { line += " "; }
                }
                Messages.PrintLine(line + "|");// Printing line and right border symbol
            }
            line = "";
            for (int j = 0; j <= Width; j++)// Printing bottom border
            {
                line += "-";
            }
            Messages.PrintLine(line);
            PrintInformation();
        }
        public int GetNeighbourCount(int i, int j)
        {
            int NeighbourCount = 0;
            for (int l = -1; l <= 1; l++)
                for (int m = -1; m <= 1; m++)
                {
                    if (i + l < 0 || j + m < 0 || i + l >= Width || j + m >= Height) continue;
                    else
                        NeighbourCount += Matrix[i + l, j + m];
                }
            NeighbourCount -= Matrix[i, j];
            return NeighbourCount;
        }
        public void Iterate()
        {
            var Factory = new Factory();
            List<ICoordinates> ToAdd = Factory.CreateListOfCoordinates();
            List<ICoordinates> ToRemove = Factory.CreateListOfCoordinates();
            for (int i = 0; i < Height; i++) // i == Width
            {
                for (int j = 0; j < Width; j++) // j == Height
                {
                    int NeighbourCount = GetNeighbourCount(j, i);
                    if (NeighbourCount == 3) // if neighbour count is 3 adding coordinates to List
                    {
                        ICoordinates coord = Factory.CreateCoordinates(j, i);
                        ToAdd.Add(coord);
                    }
                    if (NeighbourCount == 0 || NeighbourCount == 1 || NeighbourCount >= 4)// if Cell is to be destroyed Add to ToRemove List
                    {
                        ICoordinates coord = Factory.CreateCoordinates(j, i);
                        ToRemove.Add(coord);
                    }
                }
            }
            AddCells(ToAdd);
            RemoveCells(ToRemove);
            GetAliveCellCount();
            IterationCount++;
        }
        public void AddCells(List<ICoordinates> ToAdd)
        {
            foreach (var add in ToAdd)// Adding new Cells
            {
                AddCell(add.WidthCoord, add.HeightCoord);
            }
        }
        public void RemoveCells(List<ICoordinates> ToRemove)
        {
            foreach (var add in ToRemove)// Deleting Cells
            {
                RemoveCell(add.WidthCoord, add.HeightCoord);
            }
        }
        public void AddCell(int x, int y) // Adding cell to the matrix
        {
            try
            {
                if (x > Width - 1 || y > Height - 1)
                    throw new System.IndexOutOfRangeException("Index was outside the bounds of the array");
                else
                    Matrix[x, y] = 1;
            }
            catch (IndexOutOfRangeException outOfRange)
            {
                Messages.DisplayError(outOfRange.Message);
            }
        }
        public void RemoveCell(int x, int y) // Adding cell to the matrix
        {
            try
            {
                if (x > Width - 1 || y > Height - 1)
                    throw new System.IndexOutOfRangeException("Index was outside the bounds of the array");
                else
                    Matrix[x, y] = 0;
            }
            catch (IndexOutOfRangeException outOfRange)
            {
                Messages.DisplayError(outOfRange.Message);
            }
        }
        public void GetAliveCellCount()
        {
            AliveCells = 0;
            for (int i = 0; i < Width; i++) // i == Width
            {
                for (int j = 0; j < Height; j++) // j == Height
                {
                    if (Matrix[i, j] == 1) AliveCells++;
                }
            }
        }
        public void PrintInformation()
        { 
            Messages.PrintCellCounnt(AliveCells);
            Messages.PrintIterationCount(IterationCount);
        }
        public static string GetlineForPrinting(IGameOfLife game, string line, int height)
        {
            //Checking if Line lenght is greater than Console Width
            if (line.Length + game.Width > 200)
            {
                Console.WriteLine(line);
                line = "";
            }
            if (height > game.Height)
            {
                for (int j = 0; j < game.Width; j++)
                {
                line += " ";
                }
            }
            if (height == game.Height)
            {
                for (int j = 0; j < game.Width; j++)
                {
                    line += "-";
                }
                line += "-";
            }
            else
            {
                for (int j = 0; j < game.Width; j++)
                {
                    if (game.Matrix[j, height] == 1) { line += "X"; }
                    else if (game.Matrix[j, height] == 0) { line += " "; }
                }
                line += "|";
            }
            return line;
        }
        public static void PrintMatrix(IGameOfLife g1, IGameOfLife g2, IGameOfLife g3, IGameOfLife g4, IGameOfLife g5, IGameOfLife g6, IGameOfLife g7, IGameOfLife g8)//Printing Matrix
        {
            List<string> lines = new List<string>();
            for (int i = 0; i < g1.Height+1; i++)
            {
                string line = "";
                line = GetlineForPrinting(g1, line, i);
                line = GetlineForPrinting(g2, line, i);
                line = GetlineForPrinting(g3, line, i);
                line = GetlineForPrinting(g4, line, i);
                line = GetlineForPrinting(g5, line, i);
                line = GetlineForPrinting(g6, line, i);
                line = GetlineForPrinting(g7, line, i);
                line = GetlineForPrinting(g8, line, i);
                Console.WriteLine(line);
            }
        }
        public static int GetTotalCellCount(List<IGameOfLife> games)
        {
            int cellcount = 0;
            foreach (var game in games)
            {
                cellcount += game.AliveCells;
            }
            return cellcount;
        }
    }
}