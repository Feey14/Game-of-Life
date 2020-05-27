namespace GameOfLife
{
    public interface IGameOfLife
    {
        int Width { get; set; }
        int Height { get; set; }
        int[,] Matrix { get; set; }
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
