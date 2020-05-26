using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Of_Life
{
    public class GameOfLife
    {
        public struct Coordinates
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
        public List<Coordinates> Matrix { get; set; }
        public GameOfLife(int Width, int Height) // Constructor class that creates Matrix
        {
            this.Width = Width;
            this.Height = Height;
            Matrix = new List<Coordinates>();
        }
        public void PrintMatrix()//Printing Matrix
        {
            string line = "";
            for (int i = 0; i < Height; i++)
            {
                line = "";
                for (int j = 0; j < Width; j++)
                {
                    if (Matrix.Exists(x => x.WidthCoord == j && x.HeightCoord == i)) { line += "X"; }
                    else { line += " "; }
                }
                Console.WriteLine(line+"{0}",i);
            }
            line = "";
            for (int j = 0; j <= Width; j++)
            {
                line += j;
            }
            Console.WriteLine(line);

        }
        public int NeighbourCount(int WidthCoord, int HeightCoord)
        {
            int neighbours = 0;
            if (Matrix.Exists(x => x.WidthCoord == WidthCoord - 1 && x.HeightCoord == HeightCoord - 1)) { neighbours++; } // Top left
            if (Matrix.Exists(x => x.WidthCoord == WidthCoord - 1 && x.HeightCoord == HeightCoord )) { neighbours++; } // Left
            if (Matrix.Exists(x => x.WidthCoord == WidthCoord - 1 && x.HeightCoord == HeightCoord + 1)) { neighbours++; } // Bottom Left
            if (Matrix.Exists(x => x.WidthCoord == WidthCoord && x.HeightCoord == HeightCoord - 1)) { neighbours++; } // Top
            if (Matrix.Exists(x => x.WidthCoord == WidthCoord && x.HeightCoord == HeightCoord + 1)) { neighbours++; } // Bottom
            if (Matrix.Exists(x => x.WidthCoord == WidthCoord + 1 && x.HeightCoord == HeightCoord - 1)) { neighbours++; } // Top right
            if (Matrix.Exists(x => x.WidthCoord == WidthCoord + 1 && x.HeightCoord == HeightCoord)) { neighbours++; } // Right
            if (Matrix.Exists(x => x.WidthCoord == WidthCoord + 1 && x.HeightCoord == HeightCoord + 1)) { neighbours++; } // Bottom right
            return neighbours;
        }
        public void Iterate()
        {
            List<Coordinates> ToAdd = new List<Coordinates>();
            List<Coordinates> ToRemove = new List<Coordinates>();
            foreach (var cell in Matrix)
            {
                int neighbour_count = 0;
                for (int i = -1; i < 2; i++) {
                    for (int j = -1; j < 2; j++)
                    {
                        neighbour_count = NeighbourCount(cell.WidthCoord + i, cell.HeightCoord + j);
                        if (neighbour_count == 3) { ToAdd.Add(new Coordinates(cell.WidthCoord + i, cell.HeightCoord + j)); }//Console.WriteLine("in matrix {0} {1}", cell.WidthCoord, cell.HeightCoord); }
                        if (neighbour_count == 0 || neighbour_count == 1 || neighbour_count >= 4) { ToRemove.Add(new Coordinates(cell.WidthCoord + i, cell.HeightCoord + j)); }
                    }
                }
            }
            foreach (var add in ToAdd)// Adding new Cells
            {
                AddCell(add.WidthCoord, add.HeightCoord);
            }
            foreach (var remove in ToRemove)// Deleting Cells
            {
              
                
                
                
                
                
                
                
                RemoveCell(remove.WidthCoord, remove.HeightCoord);
            }
        }
        public void AddCell(int x,int y) // Adding cell to the matrix
        {
            try
            {
                if (x > Width - 1 || y > Height - 1)
                    throw new System.IndexOutOfRangeException("Index was outside the bounds of the array");
                else
                {
                    Coordinates coord;
                    coord.WidthCoord = x;
                    coord.HeightCoord = y;
                   // Console.WriteLine("in matrix {0} {1}", coord.WidthCoord, coord.HeightCoord);
                    if (Matrix.Exists(x => x.WidthCoord == coord.WidthCoord && x.HeightCoord == coord.HeightCoord)) { }
                    else
                    {
                        Matrix.Add(coord);
                    }
                }
            }
            catch(IndexOutOfRangeException outOfRange)
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
                {
                    Coordinates coord;
                    coord.WidthCoord = x;
                    coord.HeightCoord = y;
                    Matrix.Remove(coord);
                }
            }
            catch (IndexOutOfRangeException outOfRange)
            {
                Console.WriteLine("Error: {0}", outOfRange.Message);
            }
        }
    }
}
