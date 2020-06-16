using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    internal class Program
    {
        private static void Main()
        {
            bool repeat = true;
            do
            {
                List<IGameOfLife> games = new List<IGameOfLife>();
                Messages.ReadFomFileOrCreatethousandgamesOrCreateSingleGOL();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.F1:
                        if (File.Exists("../../../TestFile.bin"))
                        {
                            WorkingWithFiles file = new WorkingWithFiles();
                            games = file.ReadFromaFile();
                        }
                        else
                        {
                            Messages.FileDoesNotExist();
                            break;
                        }
                        Messages.DisplayEightOrDisplayOne(games);
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.F1:
                                DisplayEightGameOfLifeSetup(games);
                                break;

                            case ConsoleKey.F2:
                                DisplayGameOfLifeSetup(games);
                                break;
                        }
                        break;

                    case ConsoleKey.F2:
                        games = CreateThousandGames();
                        break;

                    case ConsoleKey.F3:
                        CreateGameOfLifeSetup(games);
                        break;
                }
                SaveGames(games);
                Messages.EndOfProgram();
                if (!(Console.ReadKey().Key == ConsoleKey.Y)) repeat = false;
            } while (repeat == true);
        }

        private static List<IGameOfLife> CreateThousandGames()
        {
            List<IGameOfLife> games = new List<IGameOfLife>();
            for (int i = 0; i < 1000; i++)
            {
                RandomPattern randompattern = new RandomPattern();
                IGameOfLife tempgame = new GameOfLife(30, 15);
                randompattern.Add(tempgame);
                games.Add(tempgame);
            }
            Messages.ThousandGameCreation();
            return games;
        }

        private static void SaveGames(List<IGameOfLife> games)
        {
            if (games.Count > 0)
            {
                Messages.SaveGames(games);
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    WorkingWithFiles file = new WorkingWithFiles();

                    file.WriteToaFile(games);
                    Console.Clear();
                    Messages.InformationIsSaved();
                }
            }
        }

        private static void DisplayEightGameOfLifeSetup(List<IGameOfLife> games)
        {
            List<IGameOfLife> toshow = new List<IGameOfLife>();
            UserInput userinput = new UserInput();
            TimerGOL timer = new TimerGOL();

            userinput.CaptureGameOfLifes(games, toshow);
            timer.StartTimer(games, toshow);
        }

        private static void DisplayGameOfLifeSetup(List<IGameOfLife> games)
        {
            UserInput userinput = new UserInput();
            TimerGOL timer = new TimerGOL();

            IGameOfLife game = userinput.CaptureGameNr(games);
            timer.StartTimer(game);
        }

        private static void CreateGameOfLifeSetup(List<IGameOfLife> games)
        {
            UserInput userinput = new UserInput();
            TimerGOL timer = new TimerGOL();
            LightWeightSpaceship lws = new LightWeightSpaceship();

            IGameOfLife game = userinput.Capture();//initialazing game of life
            lws.Add(game);//Adding lightweightspaceship
            timer.StartTimer(game);
            games.Add(game);
        }
    }
}