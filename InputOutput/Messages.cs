using System;
using System.Collections.Generic;

namespace GameOfLife
{
    internal class Messages
    {
        public static void WidthInputMessage()
        {
            Console.WriteLine("Enter Matrix Width Max value is 210");
        }

        public static void HeightInputMessage()
        {
            Console.WriteLine("Enter Matrix Height");
        }

        public static void DisplayError(string message)
        {
            Console.WriteLine("Error: {0}", message);
        }

        public static void PrintLine(string line)
        {
            Console.WriteLine(line);
        }

        public static void TerminatingApplicationMessage()
        {
            Console.WriteLine("Terminating the application...");
        }

        public static void PressKeyToStopMessage()
        {
            Console.WriteLine("Press any key to stop");
        }

        public static void PrintCellCount(int cellcount)
        {
            Console.WriteLine("Alive Cell Count : {0}", cellcount);
        }

        public static void PrintIterationCount(int iterationcount)
        {
            Console.WriteLine("Iteration count : {0}", iterationcount);
        }

        public static void ReadFomFileOrCreatethousandgamesOrCreateSingleGOL()
        {
            Console.Clear();
            Console.WriteLine("Press F1 if you would like to read from a file{0}Press F2 if you would like to create 1000 games{0}Press F3 if you would like to create one Game of Life", Environment.NewLine);
        }

        public static void DisplayEightOrDisplayOne(List<IGameOfLife> games)
        {
            Console.WriteLine("Item count in the list : {0}{1}Press 'F1' if you would like to display 8 games{1}Press 'F2' if you would like to display 1 game", games.Count, Environment.NewLine);
        }

        public static void EnterGameNr(int i)
        {
            Console.WriteLine("Enter game {0}:", i);
        }

        public static void ThousandGameCreation()
        {
            Console.WriteLine("Thousand games have been created");
        }

        public static void SaveGames(List<IGameOfLife> games)
        {
            Console.WriteLine("Press 'y' if you would like to save data to a file. Currently {0} games are in memory", games.Count);
        }

        public static void InformationIsSaved()
        {
            Console.WriteLine("Information has been saved to a file");
        }

        public static void EndOfProgram()
        {
            Console.WriteLine("End of Program. Press 'y' if you would like to repeat program");
        }

        public static void GameCountAndCellCount(Tuple<int, int> gameoflifestatistics)
        {
            Console.WriteLine("Live game count : {1} {2}Alive cell count : {0} ", gameoflifestatistics.Item1, gameoflifestatistics.Item2, Environment.NewLine);
        }

        public static void IterateOtherGames()
        {
            Console.WriteLine("Press F1 to enter other 8 games to iterate on the screen");
        }

        public static void EnterValidNumbers()
        {
            Console.WriteLine("Not valid, please enter numbers only");
        }

        public static void FileDoesNotExist()
        {
            Console.WriteLine("File does not exist");
        }

        public static void NotEnoughGames()
        {
            Console.WriteLine("Not enough games in memory");
        }
    }
}