using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5
{
    class VectorFile
    {
        public static void SortFile(string path)
        {
            File.WriteAllText(@"data/tempHalf1.txt", string.Empty);
            File.WriteAllText(@"data/tempHalf2.txt", string.Empty);
            int lineCount = GetNumberOfElements(path);

            using (StreamReader reader = new StreamReader(path))
            {
                WriteIntoFile(reader, @"data/tempHalf1.txt", lineCount/2);
                WriteIntoFile(reader, @"data/tempHalf2.txt", lineCount/2);
            }
            Merge(@"data/tempHalf1.txt", @"data/tempHalf2.txt", @"data/result.txt");
        }

        public static int GetNumberOfElements(string path)
        {
            int result = 0;
            using (StreamReader reader = new StreamReader(path))
            {
                while (reader.ReadLine() != null)
                {
                    result++;
                }
            }
            return result;
        }

        private static void WriteIntoFile(StreamReader reader, string resultPath, int elQuantity)
        {
            using (StreamWriter writer = new StreamWriter(resultPath))
            {
                List<int> temp = new List<int>();
                for (int i = 0; i < elQuantity; i++)
                {
                    temp.Add(int.Parse(reader.ReadLine()));
                }
                Vector vc = new Vector(temp);
                vc.SplitMergeSort();

                for (int i = 0; i < elQuantity; i++)
                {
                    writer.WriteLine(vc.Arr[i]);
                }
            }
        }

        public static void Merge(string pathInputFile1, string pathInputFile2, string pathOutputFile)
        {
            File.WriteAllText(pathOutputFile, string.Empty);
            int item1 = 0;
            int item2 = 0;
            bool endOfFile1 = false;
            bool endOfFile2 = false;
            string temp;

            var inputFile1 = File.OpenText(pathInputFile1);
            var inputFile2 = File.OpenText(pathInputFile2);
            temp = inputFile1.ReadLine();
            if (temp == null)
            {
                endOfFile1 = true;
            }
            else
            {
                item1 = Int32.Parse(temp);
            }
            temp = inputFile2.ReadLine();
            if (temp == null)
            {
                endOfFile2 = true;
            }
            else
            {
                item2 = Int32.Parse(temp);
            }

            while (!endOfFile1 && !endOfFile2)
            {
                if (item1 < item2)
                {
                    using (StreamWriter sw = File.AppendText(pathOutputFile))
                    {
                        sw.WriteLine(item1);
                    }
                    temp = inputFile1.ReadLine();
                    if (temp == null)
                    {
                        endOfFile1 = true;
                    }
                    else
                    {
                        item1 = Int32.Parse(temp);
                    }

                }
                else if (item1 == item2)
                {
                    using (StreamWriter sw = File.AppendText(pathOutputFile))
                    {
                        sw.WriteLine(item1);
                    }
                    temp = inputFile1.ReadLine();
                    if (temp == null)
                    {
                        endOfFile1 = true;
                    }
                    else
                    {
                        item1 = Int32.Parse(temp);
                    }
                    temp = inputFile2.ReadLine();
                    if (temp == null)
                    {
                        endOfFile2 = true;
                    }
                    else
                    {
                        item2 = Int32.Parse(temp);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(pathOutputFile))
                    {
                        sw.WriteLine(item2);
                    }
                    temp = inputFile2.ReadLine();
                    if (temp == null)
                    {
                        endOfFile2 = true;
                    }
                    else
                    {
                        item2 = Int32.Parse(temp);
                    }
                }
            }
            while (!endOfFile1)
            {
                using (StreamWriter sw = File.AppendText(pathOutputFile))
                {
                    sw.WriteLine(item1);
                }
                temp = inputFile1.ReadLine();
                if (temp == null)
                {
                    endOfFile1 = true;

                }
                else
                {
                    item1 = Int32.Parse(temp);
                }
            }
            while (!endOfFile2)
            {
                using (StreamWriter sw = File.AppendText(pathOutputFile))
                {
                    sw.WriteLine(item2);
                }
                temp = inputFile2.ReadLine();
                if (temp == null)
                {
                    endOfFile2 = true;
                }
                else
                {
                    item2 = Int32.Parse(temp);
                }
            }
        }

    }
}

