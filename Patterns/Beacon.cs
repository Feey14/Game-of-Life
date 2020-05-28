using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class Beacon : Patterns
    {
        public override void Add(IGameOfLife game)
        {
            game.AddCell(1, 1);
            game.AddCell(1, 2);
            game.AddCell(2, 1);
            game.AddCell(2, 2);

            game.AddCell(3, 3);
            game.AddCell(3, 4);
            game.AddCell(4, 3);
            game.AddCell(4, 4);
        }
    }
}
