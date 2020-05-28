namespace GameOfLife
{
    public struct Coordinates:ICoordinates
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
