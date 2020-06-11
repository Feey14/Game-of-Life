using System.Collections.Generic;

namespace GameOfLife
{
    public interface IGameOfLife
    {
        int AliveCells { get; set; }
        int Height { get; set; }
        int IterationCount { get; set; }
        bool[,] Matrix { get; set; }
        int Width { get; set; }

        void AddCell(int x, int y);
        void AddCells(List<Coordinates> ToAdd);
        int GetNeighbourCount(int x, int y);
        void Iterate();
        void PrintInformation();
        void PrintMatrix();
        void RemoveCell(int x, int y);
        void RemoveCells(List<Coordinates> ToRemove);
    }
}