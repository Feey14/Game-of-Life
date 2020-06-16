﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameOfLife
{
    internal class WorkingWithFiles
    {
        public List<IGameOfLife> ReadFromaFile()
        {
            try
            {
                Console.Clear();
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream("../../../TestFile.bin", FileMode.Open, FileAccess.Read))
                {
                    List<IGameOfLife> games = (List<IGameOfLife>)formatter.Deserialize(stream);
                    stream.Close();
                    return games;
                }
            }
            catch (Exception ex)
            {
                Messages.DisplayError(ex.Message);
            }
            return new List<IGameOfLife>();
        }

        public void WriteToaFile(List<IGameOfLife> games)
        {
            try
            {
                using (Stream stream = new FileStream("../../../TestFile.bin", FileMode.Create, FileAccess.Write))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, games);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                Messages.DisplayError(ex.Message);
            }
        }
    }
}