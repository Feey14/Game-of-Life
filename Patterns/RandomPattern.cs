using System;

namespace GameOfLife
{ 
    class RandomPattern : Patterns
    {
        public override void Add(IGameOfLife game)
        {
            Random random = new Random();
            for (int y=0; y<game.Height; y++)
                for (int x = 0; x < game.Width; x++)
                {
                    game.Matrix[x, y] = random.Next(2) == 0;
                }
        }
    }
}
