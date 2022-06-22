using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Task1
{
    class TextWriter
    {
        public static void Write(string text, string path = @"Task1\txtData\result.txt")
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.Write(text);
            }
        }
    }
}
