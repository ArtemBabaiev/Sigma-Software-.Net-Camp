using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HW_7.controller_services
{
    class RepairStorageController
    {
        public void RepairFromLogs(string logPath, DateTime date)
        {
            using (StreamReader logReader = new StreamReader(logPath))
            {
                while (!logReader.EndOfStream)
                {
                    string logLine = logReader.ReadLine();
                    Match logDateStr = Regex.Match(logLine, @"(\d{2}-\d{2}-\d{4} \d{2}:\d{2}:\d{2})");
                    DateTime logDate = DateTime.Parse(logDateStr.Value);
                    if (DateTime.Compare(logDate, date) > 0)
                    {
                        Console.WriteLine(logLine);
                        Console.WriteLine("Repair? Answer(y/n): ");
                        string answ = Console.ReadLine();
                        if (answ != "y")
                        {
                            continue;
                        }
                        string file = Regex.Match(logLine, @"--(.+)--").Value.Replace("--", "");
                        int line = int.Parse(Regex.Match(logLine, @"\+(.+)\+").Value.Replace("+", ""));
                        using (StreamReader dataReader = new StreamReader(file))
                        {
                            int readLineNumber = 0;
                            string oldProduct;
                            do
                            {
                                oldProduct = dataReader.ReadLine();
                                readLineNumber++;
                            } while (readLineNumber != line);
                            Console.WriteLine("Old data: " + oldProduct);
                        }

                        Console.Write("Enter new data: ");
                        string newData = Console.ReadLine();
                        var lines = File.ReadLines(file).ToArray();
                        lines[line - 1] = newData;
                        File.WriteAllLines(file, lines);
                    }
                }

            }
        }
    }
}
