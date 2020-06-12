namespace GameOfLife
{
    class LightWeightSpaceship : Patterns
    {
        public override void Add(IGameOfLife game)
        {
            if (game.Width >= 6 && game.Height >= 5)
            {
                game.AddCell(1, 1);
                game.AddCell(4, 1);
                game.AddCell(5, 2);
                game.AddCell(1, 3);
                game.AddCell(5, 3);
                game.AddCell(2, 4);
                game.AddCell(3, 4);
                game.AddCell(4, 4);
                game.AddCell(5, 4);
            }
        }
    }
}
