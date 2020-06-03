using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameOfLife
{
    class WriteToFile
    {
        public static void WriteToaFile(List<IGameOfLife> games)
        {
            try
            {
                Stream stream = new FileStream("../../../TestFile.bin", FileMode.Create, FileAccess.Write);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, games);
                stream.Close();
            }
            catch(Exception ex)
            {
                Messages.DisplayError(ex.Message);
            }
        }
    }
}
