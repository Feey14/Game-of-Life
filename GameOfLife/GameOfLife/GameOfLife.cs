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
            foreach (Coordinates add in ToAdd)// Adding new Cells
            {
                if (Matrix[add.WidthCoord, add.HeightCoord] == false)
                {
                    AddCell(add.WidthCoord, add.HeightCoord);
                }
            }
        }

        public void RemoveCells(List<Coordinates> ToRemove)
        {
            foreach (Coordinates add in ToRemove)// Deleting Cells
            {
                if (Matrix[add.WidthCoord, add.HeightCoord] == true)
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
            Messages.PrintCellCount(AliveCells);
            Messages.PrintIterationCount(IterationCount);
        }
    }
}