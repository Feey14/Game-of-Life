namespace GameOfLife
{
    public interface IGameOfLife
    {
        int Width { get; set; }
        int Height { get; set; }
        int[,] Matrix { get; set; }
        void AddCell(int x, int y);
        int GetNeighbourCount(int i, int j);
        void Iterate();
        void PrintMatrix();
        void RemoveCell(int x, int y);
    }
}