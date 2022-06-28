using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HW_12.Task1.validators;
using HW_12.Task1.exceptions;

namespace HW_12.Task1.fillers
{
    static class StorageFileReader
    {
        public static string[] Read(string path = @"Task1and2/txtData/StorageData.txt")
        {
            List<string> data = new();
            try
            {
                using (StreamReader reader = new(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (Validation.IsValidLine(line))
                        {
                            data.Add(line);
                        }

                    }
                }
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                throw;
            }
            return data.ToArray();
        }

    }
}
