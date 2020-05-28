using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class Patterns
    {
        public static void LightWeightSpaceship(IGameOfLife game)
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
        public static void Glider(IGameOfLife game)
        {
            game.AddCell(11, 10);
            game.AddCell(12, 11);
            game.AddCell(10, 12);
            game.AddCell(11, 12);
            game.AddCell(12, 12);
        }
        public static void Beacon(IGameOfLife game)
        {
            //Beacon 
            game.AddCell(1, 1);
            game.AddCell(1, 2);
            game.AddCell(2, 1);
            game.AddCell(2, 2);

            game.AddCell(3, 3);
            game.AddCell(3, 4);
            game.AddCell(4, 3);
            game.AddCell(4, 4);
        }
        public static void SimkinGliderGun(IGameOfLife game)
        {
            game.AddCell(3, 1);
            game.AddCell(3, 2);
            game.AddCell(4, 1);
            game.AddCell(4, 2);

            game.AddCell(7, 4);
            game.AddCell(8, 4);
            game.AddCell(7, 5);
            game.AddCell(8, 5);

            game.AddCell(10, 1);
            game.AddCell(10, 2);
            game.AddCell(11, 1);
            game.AddCell(11, 2);

            game.AddCell(23, 18);
            game.AddCell(23, 19);
            game.AddCell(24, 18);
            game.AddCell(24, 20);
            game.AddCell(25, 20);
            game.AddCell(26, 20);
            game.AddCell(26, 21);

            game.AddCell(24, 11);
            game.AddCell(24, 12);
            game.AddCell(24, 13);
            game.AddCell(25, 10);
            game.AddCell(26, 10);
            game.AddCell(25, 13);
            game.AddCell(26, 13);

            game.AddCell(28, 10);
            game.AddCell(29, 10);
            game.AddCell(30, 11);
            game.AddCell(31, 12);
            game.AddCell(30, 13);
            game.AddCell(29, 14);

            game.AddCell(34, 12);
            game.AddCell(35, 12);
            game.AddCell(34, 13);
            game.AddCell(35, 13);
        }

    }
}
