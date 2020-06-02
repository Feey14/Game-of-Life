using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace GameOfLife
{
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
                    if (i + l < 0 || j + m < 0 || i + l >= Height || j + m >= Width) continue;
                    else
                        NeighbourCount += Matrix[i + l, j + m];
                }
            NeighbourCount -= Matrix[i, j];
            return NeighbourCount;
        }
        public void Iterate()
        {
            List<ICoordinates> ToAdd = Factory.CreateListOfCoordinates();
            List<ICoordinates> ToRemove = Factory.CreateListOfCoordinates();
            for (int i = 0; i < Width; i++) // i == Width
            {
                for (int j = 0; j < Height; j++) // j == Height
                {
                    int NeighbourCount = GetNeighbourCount(i, j);
                    if (NeighbourCount == 3) // if neighbour count is 3 adding coordinates to List
                    {
                        ICoordinates coord = Factory.CreateCoordinates(i, j);
                        ToAdd.Add(coord);
                    }
                    if (NeighbourCount == 0 || NeighbourCount == 1 || NeighbourCount >= 4)// if Cell is to be destroyed Add to ToRemove List
                    {
                        ICoordinates coord = Factory.CreateCoordinates(i, j);
                        ToRemove.Add(coord);
                    }
                }
            }
            AddCells(ToAdd);
            RemoveCells(ToRemove);
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
    }
}