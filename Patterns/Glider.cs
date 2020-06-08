namespace GameOfLife
{
    class Glider : Patterns
    {
        public override void Add(IGameOfLife game)
        {
            game.AddCell(11, 10);
            game.AddCell(12, 11);
            game.AddCell(10, 12);
            game.AddCell(11, 12);
            game.AddCell(12, 12);
        }
    }
}
