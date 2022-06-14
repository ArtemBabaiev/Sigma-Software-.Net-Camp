using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8.Task2
{
    class WebStatHandler
    {
        private string path;

        public WebStatHandler() : this(default)
        {
        }

        public WebStatHandler(string path)
        {
            this.Path = path;
        }

        public string Path { get => path; protected set => path = value; }

        public int GetSitesVisitByIp(string ipAdderss)
        {
            int count = 0;
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Contains(ipAdderss))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public string GetMostPopularDayOfWeek()
        {
                Dictionary<String, int> stat = GetDictionaryWithFrequency(line => line.Split(" ")[2], path);
                
                if (stat.Count == 0)
                {
                    return "";
                }
                return GetKeyWithHighsetValue(stat);
        }
        
        public string GetMostPopularTime()
        {
            Dictionary<string, int> stat = GetDictionaryWithFrequency(line => line.Split(" ")[1].Split(":")[0], path);
            
            if (stat.Count == 0)
            {
                return null;
            }

            string max = GetKeyWithHighsetValue(stat);
            if (max == null)
            {
                return null;
            }
            return $"{max}:00:00 - {max}:59:59";
        }

        public string GetMostPopularTimeInDay(string day)
        {
            
            using (StreamReader reader = new StreamReader(path))
            {
                using (StreamWriter writer = File.CreateText(@"Task2/txtData/temp.txt"))
                {
                    string line = reader.ReadLine();
                    if (line.Contains(day))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            Dictionary<string, int> stat = GetDictionaryWithFrequency(line => line.Split(" ")[1].Split(":")[0], @"Task2/txtData/temp.txt");
            File.Delete(@"Task2/txtData/temp.txt");
            string max = GetKeyWithHighsetValue(stat);
            if (max == null)
            {
                return null;
            }
            return $"{max}:00:00 - {max}:59:59";
        }

        private Dictionary<String, int> GetDictionaryWithFrequency(Func<string, string> keyEvaluation, string pathToFile)
        {
            try
            {
                Dictionary<String, int> stat = new();
                using (StreamReader reader = new StreamReader(pathToFile))
                {
                    while (!reader.EndOfStream)
                    {
                        string tempKey = keyEvaluation(reader.ReadLine()).ToLower();
                        if (tempKey.Length == 0)
                        {
                            continue;
                        }
                        if (!stat.ContainsKey(tempKey))
                        {
                            stat.Add(tempKey, 1);
                            continue;
                        }
                        else
                        {
                            stat[tempKey]++;
                        }
                    }
                }
                return stat;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        
        private string GetKeyWithHighsetValue(Dictionary<string, int> stat)
        {
            try
            {
                string max = (from item in stat where item.Value == stat.Max(v => v.Value) select item.Key).ToArray()[0];
                return max;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
