using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace GameOfLife
{
    class Factory
    {
        public static IGameOfLife CreateGameOfLife(int Width, int Height)
        {
            return new GameOfLife(Width, Height);
        }
        public static List<IGameOfLife> CreateListOfGameOfLife()
        {
            return new List<IGameOfLife>();
        }
        public static ICoordinates CreateCoordinates()
        {
            return new Coordinates();
        }
        public static ICoordinates CreateCoordinates(int x, int y)
        {
            return new Coordinates(x, y);
        }
        public static List<ICoordinates> CreateListOfCoordinates()
        {
            return new List<ICoordinates>();
        }
        public static Timer CreateTimer()
        {
            return new Timer(1000);
        }
        public static List<IGameOfLife> CreateThousandGames()
        {
            List<IGameOfLife> thousandgames = Factory.CreateListOfGameOfLife();
            var beacon = new Beacon();
            IGameOfLife game = CreateGameOfLife(5,5);
            beacon.Add(game);
            for (int i = 0; i < 1000; i++)
            {
                thousandgames.Add(game);
            }
            return thousandgames;
        }

    }
}
