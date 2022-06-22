using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Task1
{
    class TextReader
    {
        public static string Read(string path = @"Task1\txtData\Text.txt")
        {
            return File.ReadAllText(path);
        }
    }
}
