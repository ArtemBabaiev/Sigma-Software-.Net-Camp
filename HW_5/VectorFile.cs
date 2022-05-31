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
        }

        private static void MergeIntoFile(string path)
        {

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

        private static void MergeIntoFile(string firstHalfPath, string secondHalfPath)
        {
            _ = File.AppendText(@"result.txt");

        }
    }
}
