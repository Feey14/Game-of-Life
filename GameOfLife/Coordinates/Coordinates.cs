﻿namespace GameOfLife
{
    public struct Coordinates
    {
        public int HeightCoord { get; set; }
        public int WidthCoord { get; set; }

        public Coordinates(int x, int y)
        {
            WidthCoord = x;
            HeightCoord = y;
        }
    }
}