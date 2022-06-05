using HW_6.Task1.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_6.Task1.controller
{
    class FileController
    {

        public FileController()
        {
        }

        public Report FillReportFromFile(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    var headerPattern = @"[1-9]{1,} [1-4]";
                    var headerReg = new Regex(headerPattern);
                    string header = reader.ReadLine();

                    if (!headerReg.IsMatch(header))
                    {
                        throw new Exception("Invalid File header");
                    }

                    List<string> data = header.Split(" ").ToList();
                    int appartmentQuantity = int.Parse(data[0]);
                    int reportNumber = int.Parse(data[1]);

                    string exepctionMessage = "";

                    List<Appartment> appartments = new List<Appartment>(appartmentQuantity);
                    for (int i = 0; i < appartmentQuantity; i++)
                    {

                        var logPattern = @"[1-9][0-9]{0,} [a-zA-ZА-Яа-яІіЇї]{1,} ([0-9]{1,},[0-9]{1,} ){2}([0-9]{2}\.[0-9]{2}\.[0-9]{4} ){2}[0-9]{2}\.[0-9]{2}\.[0-9]{4}";
                        Regex reg = new Regex(logPattern);
                        string line = reader.ReadLine();
                        if (!reg.IsMatch(line))
                        {
                            exepctionMessage += $"Invalid data in line {i + 2}\n";
                        }
                        else
                        {
                            List<string> appartmentData = line.Split(" ").ToList();
                            int appNumber = int.Parse(appartmentData[0]);
                            string name = appartmentData[1];
                            var meterData = new ElectricMeterData(
                                        double.Parse(appartmentData[2]),
                                        double.Parse(appartmentData[3]),
                                        new DateTime[] { DateTime.Parse(appartmentData[4]), DateTime.Parse(appartmentData[5]), DateTime.Parse(appartmentData[6]) });
                            appartments.Add(new Appartment(appNumber, name, meterData));
                        }
                    }
                    Console.WriteLine(exepctionMessage);
                    return new Report(reportNumber, appartments);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File \"{path}\" does not exist");
                return null;
            }

        }


        private void CreateAndWriteFile(string content, string fileName)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(Task1PathConstants.TXT_DIRECTORY + @$"/{fileName}"))
                {
                    writer.Write(content);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(Task1PathConstants.TXT_DIRECTORY);
                CreateAndWriteFile(content, fileName);
            }
        }


        public void WriteReportToFile(Report report, string fileName)
        {

            string months = Quarter.GetQuarterMonths(report.QuarterNumber) + "\n";

            int width = "Owner name".Length;
            
            int max = report.Appartments.Max(app => app.OwnerName.Length);
            if (max > "Owner name".Length)
            {
                width = max;
            }
            string header = GetTableHeader(width);
            string content = "";
            foreach (var item in report.Appartments)
            {
                content += AppartmentToTableString(item, width);
            }
            CreateAndWriteFile(months + header + content, fileName);

        }

        public void WriteAppartmentInfoToFile(Appartment appartment)
        {
            string fileName = $"appartment_№{appartment.Number}_Data.txt";
            int width = "Owner name".Length;
            if (appartment.OwnerName.Length > "Owner name".Length)
            {
                width = appartment.OwnerName.Length;
            }

            string header = GetTableHeader(width);
            string content = AppartmentToTableString(appartment, width);

            CreateAndWriteFile(header + content, fileName);

        }


        private string CenterString(string source, int length)
        {
            int spaces = length - source.Length;
            int padLeft = spaces / 2 + source.Length;
            return source.PadLeft(padLeft, '.').PadRight(length, '.');
        }

        private string AppartmentToTableString(Appartment appartment, int nameLenght)
        {
            string number = CenterString(appartment.Number.ToString(), 10);
            string name = CenterString(appartment.OwnerName, Convert.ToInt32(nameLenght * 1.5));
            var meterData = appartment.MeterData;
            var orig = CenterString(meterData.OriginalMeterDisplay.ToString(), 30);
            var last = CenterString(meterData.LastMeterDisplay.ToString(), 30);
            var first = CenterString(meterData.DatesOfMeterReading[0].ToString("dd.MM.yyyy"), 14);
            var second = CenterString(meterData.DatesOfMeterReading[1].ToString("dd.MM.yyyy"), 14);
            var third = CenterString(meterData.DatesOfMeterReading[2].ToString("dd.MM.yyyy"), 14);
            string content = $"{number}|{name}|{orig}|{last}|{first}|{second}|{third}|\n";
            return content;
        }

        private string GetTableHeader(int nameLenght)
        {
            string header = $"{CenterString("Number", 10)}|" +
                $"{CenterString("Owner name", Convert.ToInt32(nameLenght * 1.5))}|" +
                $"{CenterString("Original meter display", 30)}|" +
                $"{CenterString("Last meter display", 30)}|" +
                $"{CenterString("First Data", 14)}|" +
                $"{CenterString("Second Data", 14)}|" +
                $"{CenterString("Third Data", 14)}|\n";
            return header;
        }
    
        
    }
}
