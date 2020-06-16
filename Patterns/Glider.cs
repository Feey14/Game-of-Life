namespace GameOfLife
{
    internal class Glider : Patterns
    {
        public override void Add(IGameOfLife game)
        {
            if (game.Width >= 13 && game.Height >= 13)
            {
                game.AddCell(11, 10);
                game.AddCell(12, 11);
                game.AddCell(10, 12);
                game.AddCell(11, 12);
                game.AddCell(12, 12);
            }
        }
    }
}