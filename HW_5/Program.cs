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
            Console.WriteLine("*******************************************************************************");
            vector.HeapSort(SortOrder.ASCENDING);
            Console.WriteLine(vector);
            Console.WriteLine("*******************************************************************************");
            Random rand = new Random();
            Vector v1 = new(50);
            v1.RandomInitialization(0, 60);
            v1.SplitMergeSort();
            Console.WriteLine(v1);
            Console.WriteLine("*******************************************************************************");
            VectorFile.SortFile(@"data/ArrayData.txt");
        }
    }
}
