using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.file_work
{
    internal class FileManipulation
    {
        private string filePath;

        public FileManipulation(string filePath = @"txtData/Person.txt")
        {
            this.FilePath = filePath;
        }
        public string FilePath
        {
            get => filePath;
            set
            {
                if (value != null && value != "")
                {
                    filePath = value;
                }
                else
                {
                    throw new ArgumentException("value cant be null or empty string");
                }
            }
        }

        public List<string> ReadLines()
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            List<string> result = new();
            using (StreamReader reader = new(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null && line != "") result.Add(line);
                }
            }

            return result;
        }

        public void ClearFile()
        {
            File.WriteAllText(FilePath, "");
        }
    }
}
