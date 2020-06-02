using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameOfLife
{
    class ReadingFromFile
    {
        public static List<IGameOfLife> ReadFromaFile()
        {
            Console.Clear();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("../../../TestFile.bin", FileMode.Open, FileAccess.Read);
            List<IGameOfLife> games = (List<IGameOfLife>)formatter.Deserialize(stream);
            return games;
        }
    }
}
