using HW_10.Task1.exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_10.Task1
{
    class DictionaryReader
    {
        public static Dictionary<string, string> Read(string path = @"Task1/txtData/Dictionary.txt")
        {
            Dictionary<string, string> dict = new();
            using (StreamReader reader = new(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (Regex.IsMatch(line, @"(\w|[А-Яа-яІіЇї])+( (\w|[А-Яа-яІіЇї])+)*-((\w|[А-Яа-яІіЇї])+( (\w|[А-Яа-яІіЇї])+)*)*"))
                    {
                        var data = line.Split("-");
                        if (dict.ContainsKey(data[0]))
                        {
                            throw new DictionaryWordDublicateException($"Word \"{data[0]}\" already exist in dictinary");
                        }
                        dict.Add(data[0], data[1]);
                    }
                    else
                    {
                        throw new DictionaryLineException($"Incorrect line format: {line} ");
                    }
                }
            }
            return dict;
        }
    }
}
