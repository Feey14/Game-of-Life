using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class GameOfLifeModel:IGameOfLife
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int[,] Matrix { get; set; }
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
    }
}
