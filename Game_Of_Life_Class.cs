using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Of_Life
{
    public class GameOfLife
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int[,] Matrix { get; set; }
        struct Coordinates
        {
            public int HeightCoord;
            public int WidthCoord;
        }
        public GameOfLife(int Width, int Height) // Constructor class that creates Matrix
        {
            this.Width = Width;
            this.Height = Height;
            Matrix = new int[Width, Height];
        }
        public void PrintMatrix()//Printing Matrix
        {
            for (int i = 0; i < Height; i++)
            {
                string line = "";
                for (int j = 0; j < Width; j++)
                {
                    if (Matrix[j, i] == 1) { line += "X"; }
                    else if (Matrix[j, i] == 0) { line += " "; }
                }
                Console.WriteLine(line);
            }
        }
        public void iterate()
        {
            List<Coordinates> ToAdd = new List<Coordinates>();
            List<Coordinates> ToRemove = new List<Coordinates>();
            for (int i = 0; i < Width; i++) // i == Width
            {
                int neighbour_count = 0;
                for (int j = 0; j < Height; j++) // j == Height
                {
                    neighbour_count = 0;
                    if (i == 0 && j == 0) // Top left corner
                    {
                        if (Matrix[i + 1, j] == 1) neighbour_count++; // Cell to the right
                        if (Matrix[i + 1, j + 1] == 1) neighbour_count++; // Cell to the bottom right
                        if (Matrix[i, j + 1] == 1) neighbour_count++; // Cell to the bottom
                    }
                    else
                    if (i == Width - 1 && j == 0) // Top right corner
                    {
                        if (Matrix[i - 1, j] == 1) neighbour_count++;
                        if (Matrix[i - 1, j + 1] == 1) neighbour_count++;
                        if (Matrix[i, j + 1] == 1) neighbour_count++;
                    }
                    else
                    if (i == 0 && j == Height - 1)// Bottom left corner
                    {
                        if (Matrix[i + 1, j] == 1) neighbour_count++;
                        if (Matrix[i + 1, j - 1] == 1) neighbour_count++;
                        if (Matrix[i, j - 1] == 1) neighbour_count++;
                    }
                    else
                    if (i == Width - 1 && j == Height - 1)// Bottom right corner
                    {
                        if (Matrix[i, j - 1] == 1) neighbour_count++;
                        if (Matrix[i - 1, j - 1] == 1) neighbour_count++;
                        if (Matrix[i - 1, j] == 1) neighbour_count++;
                    }
                    else
                    if (i == 0)// Left of the Matrix
                    {
                        if (Matrix[i, j + 1] == 1) neighbour_count++;
                        if (Matrix[i + 1, j + 1] == 1) neighbour_count++;
                        if (Matrix[i + 1, j] == 1) neighbour_count++;
                        if (Matrix[i + 1, j - 1] == 1) neighbour_count++;
                        if (Matrix[i, j - 1] == 1) neighbour_count++;
                    }
                    else
                    if (i == Width - 1) // Right of the Matrix
                    {
                        if (Matrix[i, j + 1] == 1) neighbour_count++;
                        if (Matrix[i - 1, j + 1] == 1) neighbour_count++;
                        if (Matrix[i - 1, j] == 1) neighbour_count++;
                        if (Matrix[i - 1, j - 1] == 1) neighbour_count++;
                        if (Matrix[i - 1, j] == 1) neighbour_count++;
                    }
                    else
                    if (j == 0)// Top of the Matrix
                    {
                        if (Matrix[i - 1, j] == 1) neighbour_count++;
                        if (Matrix[i - 1, j + 1] == 1) neighbour_count++;
                        if (Matrix[i, j + 1] == 1) neighbour_count++;
                        if (Matrix[i + 1, j + 1] == 1) neighbour_count++;
                        if (Matrix[i + 1, j] == 1) neighbour_count++;
                    }
                    else
                    if (j == Height - 1) // Bottom of the matrix
                    {
                        if (Matrix[i - 1, j] == 1) neighbour_count++;
                        if (Matrix[i - 1, j - 1] == 1) neighbour_count++;
                        if (Matrix[i, j - 1] == 1) neighbour_count++;
                        if (Matrix[i + 1, j - 1] == 1) neighbour_count++;
                        if (Matrix[i + 1, j] == 1) neighbour_count++;
                    }
                    else  //Matrix Cell that isnt within matrix edges
                    {
                        if (Matrix[i - 1, j + 1] == 1) neighbour_count++; // down left
                        if (Matrix[i, j + 1] == 1) neighbour_count++; // down center
                        if (Matrix[i + 1, j + 1] == 1) neighbour_count++;// down right
                        if (Matrix[i - 1, j] == 1) neighbour_count++;//center left
                        if (Matrix[i + 1, j] == 1) neighbour_count++;//center right
                        if (Matrix[i - 1, j - 1] == 1) neighbour_count++;//up left
                        if (Matrix[i, j - 1] == 1) neighbour_count++;//up center
                        if (Matrix[i + 1, j - 1] == 1) neighbour_count++;//up right
                    }
                    if (neighbour_count == 3) // if neighbour count is 3 adding coordinates to List
                    {
                        Coordinates coord = new Coordinates();
                        coord.HeightCoord = j;
                        coord.WidthCoord = i;
                        ToAdd.Add(coord);
                    }
                    if (neighbour_count == 0 || neighbour_count == 1 || neighbour_count >= 4)// if Cell is to be destroyed Add to ToRemove List
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
                Matrix[add.WidthCoord, add.HeightCoord] = 1;
            }

            foreach (var add in ToRemove)// Deleting Cells
            {
                Matrix[add.WidthCoord, add.HeightCoord] = 0;
            }
        }
        public void AddCell(int x,int y) // Adding cell to the matrix
        {
            try
            {
                if (x > Width - 1 || y > Height - 1)
                    throw new System.IndexOutOfRangeException("Index was outside the bounds of the array");
                else
                Matrix[x, y] = 1;
            }
            catch(IndexOutOfRangeException outOfRange)
            {
                Console.WriteLine("Error: {0}", outOfRange.Message);
            }

        }
    }
}
