﻿using System;
using System.Collections.Generic;

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
            string line;
            for (int y = 0; y < Height; y++)
            {
                line = "";
                for (int x = 0; x < Width; x++)
                {
                    if (Matrix[x, y] == true) { line += "X"; }
                    else if (Matrix[x, y] == false) { line += " "; }
                }
                Messages.PrintLine(line + "|");// Printing line and right border symbol
            }
            line = "";
            for (int x = 0; x <= Width; x++)// Printing bottom border
            {
                line += "-";
            }
            Messages.PrintLine(line);
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
            var Factory = new Factory();
            List<ICoordinates> ToAdd = Factory.CreateListOfCoordinates();
            List<ICoordinates> ToRemove = Factory.CreateListOfCoordinates();
            for (int y = 0; y < Height; y++) // i == Width
            {
                for (int x = 0; x < Width; x++) // j == Height
                {
                    int NeighbourCount = GetNeighbourCount(x, y);
                    if (NeighbourCount == 3) // if neighbour count is 3 adding coordinates to List
                    {
                        ICoordinates coord = Factory.CreateCoordinates(x, y);
                        ToAdd.Add(coord);
                    }
                    if (NeighbourCount == 0 || NeighbourCount == 1 || NeighbourCount >= 4)// if Cell is to be destroyed Add to ToRemove List
                    {
                        ICoordinates coord = Factory.CreateCoordinates(x, y);
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
                    Matrix[x, y] = true;
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
                    Matrix[x, y] = false;
            }
            catch (IndexOutOfRangeException outOfRange)
            {
                Messages.DisplayError(outOfRange.Message);
            }
        }
        public void GetAliveCellCount()
        {
            AliveCells = 0;
            for (int y = 0; y < Width; y++) // i == Width
            {
                for (int x = 0; x < Height; x++) // j == Height
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
            List<string> lines = new List<string>();
            int linecount = 0;
            int consoleWidth = 110;
            int maxheight = 0;
            foreach (var game in ToIterate)
            {
                if (game.Height > maxheight) { maxheight = game.Height; }
            }
            for (int i = 0; i <= maxheight; i++)
            {
                string line = "";
                foreach(var game in ToIterate)
                {
                    line = GetlineForPrinting(game, line, i);
                }
                lines.Add(line);
            }
            float division = (lines[0].Length / consoleWidth);
            linecount = (int)Math.Ceiling(division) +1;
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
                            templine += miniline+"|";
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
                foreach(var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public static string GetlineForPrinting(IGameOfLife game, string line, int height)
        {
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
                line += "|";
            }
            else
            {
                for (int j = 0; j < game.Width; j++)
                {
                    if (game.Matrix[j, height] == true) { line += "X"; }
                    else if (game.Matrix[j, height] == false) { line += " "; }
                }
                line += "|";
            }
            return line;
        }
    }
}