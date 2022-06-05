using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_6.Task2
{
    class TextFileManipulator
    {
        private string path;


        public TextFileManipulator(string path)
        {
            this.Path = path;
        }

        public string Path { get => path; set => path = value; }

        public string GetFileContent()
        {
            string result;
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    result = reader.ReadToEnd();
                }
                return result;

            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File doenst exist");
            }

        } 

        public string[] SplitTextBySentence()
        {
            string text = GetFileContent();
           
            //спліт за реченнями
            string[] sentences = Regex.Split(text, @"(?<=[\.!\?])\s+");
            for (int i = 0; i < sentences.Length; i++)
            {
                sentences[i] = CleanSentence(sentences[i]);
            }
            return sentences;
        }

        public List<(string, string)> GetMinMaxOfSentences(string[] contents)
        {
            List<(string, string)> result = new List<(string, string)>();
            foreach (var sentence in contents)
            {
                try
                {
                    string[] words = Regex.Split(Regex.Replace(sentence, @"[^A-Za-zА-Яа-яІіЇі ]", ""), @" +");
                    string[] sortedWords = words.OrderByDescending(word => word.Length).ToArray();
                    result.Add((sortedWords[^1], sortedWords[1]));
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
            return result;
        }

        private string CleanSentence(string sentence)
        {
            Regex reg = new Regex(@"\s+");
            return reg.Replace(sentence, " ");
        }

        public void WriteToFile(string content, string fileName)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(@$"Task2/txtFiles/{fileName}"))
                {
                    writer.Write(content);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(@$"Task2/txtFiles");
                WriteToFile(content, fileName);
            }

        }

        public void WriteToFile(string[] contents, string fileName)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(@$"Task2/txtFiles/{fileName}"))
                {
                    foreach (var item in contents)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(@$"Task2/txtFiles");
                WriteToFile(contents, fileName);
            }
        }
    }
}
