using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class GameOfLife
    {
        struct Coordinates
        {
            public int HeightCoord;
            public int WidthCoord;
            public Coordinates(int x, int y)
            {
                HeightCoord = x;
                WidthCoord = y;
            }
        }
        public int Width { get; set; }
        public int Height { get; set; }
        public int[,] Matrix { get; set; }
        public GameOfLife(int Width, int Height) // Constructor class that creates Matrix
        {
            this.Width = Width;
            this.Height = Height;
            Matrix = new int[Width, Height];
        }
        public void PrintMatrix()//Printing Matrix
        {
            string line;
            for (int i = 0; i < Height; i++)
            {
                line = "";
                for (int j = 0; j < Width; j++)
                {
                    if (Matrix[j, i] == 1) { line += "X"; }
                    else if (Matrix[j, i] == 0) { line += " "; }
                }
                Console.WriteLine(line + "|");// Printing line and right border symbol
            }
            line = "";
            for (int j = 0; j <= Width; j++)// Printing bottom border
            {
                line += "-";
            }
            Console.WriteLine(line);
        }
        public void Iterate()
        {
            List<Coordinates> ToAdd = new List<Coordinates>();
            List<Coordinates> ToRemove = new List<Coordinates>();
            
            for (int i = 0; i < Width; i++) // i == Width
            {
                int NeighbourCount;
                for (int j = 0; j < Height; j++) // j == Height
                {
            
                    NeighbourCount = 0;
                    for (int l = -1; l <= 1; l++)
                        for (int m = -1; m <= 1; m++)
                        {
                            if (i + l < 0 || j + m < 0 || i + l >= Height || j + m >= Width) continue;
                            else
                                NeighbourCount += Matrix[i + l, j + m];
                        }

                    NeighbourCount -= Matrix[i, j];

                    if (NeighbourCount == 3) // if neighbour count is 3 adding coordinates to List
                    {
                        Coordinates coord = new Coordinates();
                        coord.HeightCoord = j;
                        coord.WidthCoord = i;
                        ToAdd.Add(coord);
                    }
                    if (NeighbourCount == 0 || NeighbourCount == 1 || NeighbourCount >= 4)// if Cell is to be destroyed Add to ToRemove List
                    {
                        Coordinates coord = new Coordinates();
                        coord.HeightCoord = j;
                        coord.WidthCoord = i;
                        ToRemove.Add(coord);
                    }
                }
            }
            foreach (var add in ToAdd)// Adding new Cells
            {
                AddCell(add.WidthCoord, add.HeightCoord);
            }

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
                Console.WriteLine("Error: {0}", outOfRange.Message);
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
                Console.WriteLine("Error: {0}", outOfRange.Message);
            }
        }
    }
}