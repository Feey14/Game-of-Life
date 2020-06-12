namespace GameOfLife
{
    class LightWeightSpaceship : Patterns
    {
        public override void Add(IGameOfLife game)
        {
            if (game.Width >= 16 && game.Height >= 15)
            {
                game.AddCell(11, 11);
                game.AddCell(14, 11);
                game.AddCell(15, 12);
                game.AddCell(11, 13);
                game.AddCell(15, 13);
                game.AddCell(12, 14);
                game.AddCell(13, 14);
                game.AddCell(14, 14);
                game.AddCell(15, 14);
            }
        }
    }
}
