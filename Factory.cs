using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace GameOfLife
{
    class Factory
    {
        public IGameOfLife CreateGameOfLife(int Width, int Height)
        {
            return new GameOfLife(Width, Height);
        }
        public List<IGameOfLife> CreateListOfGameOfLife()
        {
            return new List<IGameOfLife>();
        }
        public ICoordinates CreateCoordinates()
        {
            return new Coordinates();
        }
        public ICoordinates CreateCoordinates(int x, int y)
        {
            return new Coordinates(x, y);
        }
        public List<ICoordinates> CreateListOfCoordinates()
        {
            return new List<ICoordinates>();
        }
        public Timer CreateTimer()
        {
            return new Timer(1000);
        }
        public List<IGameOfLife> CreateThousandGames()
        {
            var Factory = new Factory();
            List<IGameOfLife> thousandgames = Factory.CreateListOfGameOfLife();
            for (int i = 0; i < 1000; i++)
            {
                var beacon = new Beacon();
                IGameOfLife game = CreateGameOfLife(10, 5);
                beacon.Add(game);
                thousandgames.Add(game);
            }
            return thousandgames;
        }

    }
}
