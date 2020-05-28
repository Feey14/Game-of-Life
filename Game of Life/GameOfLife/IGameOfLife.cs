using System.Collections.Generic;

namespace GameOfLife
{
    public interface IGameOfLife
    {
        int Height { get; set; }
        int[,] Matrix { get; set; }
        int Width { get; set; }

        void AddCell(int x, int y);
        void AddCells(List<ICoordinates> ToAdd);
        int GetNeighbourCount(int i, int j);
        void Iterate();
        void PrintMatrix();
        void RemoveCell(int x, int y);
        void RemoveCells(List<ICoordinates> ToRemove);
    }
}