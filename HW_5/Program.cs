using System;
using System.IO;

namespace HW_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector = new Vector(30);
            vector.RandomInitialization(-10, 30);
            vector.HeapSort(SortOrder.DESCENDING);
            Console.WriteLine(vector);
            vector.HeapSort(SortOrder.ASCENDING);
            Console.WriteLine(vector);

            Random rand = new Random();
            string[] randNumbers = new string[100];
            for (int i = 0; i < 100; i++)
            {
                randNumbers[i] = rand.Next(-50, 50).ToString();
            }
            File.AppendAllLines(@"data/ArrayData.txt", randNumbers);

        }
    }
}
