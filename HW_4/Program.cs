using System;

namespace HW_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vc1 = new Vector(50);
            vc1.RandomInitialization(0, 30);
            vc1.QuickSort(Pivot.START);
            Console.WriteLine(vc1);
            Console.WriteLine("*******************************\n*******************************");

            Vector vc2 = new Vector(50);
            vc2.RandomInitialization(0, 30);
            vc2.QuickSort(Pivot.MIDDLE);
            Console.WriteLine(vc2);
            Console.WriteLine("*******************************\n*******************************");

            Vector vc3 = new Vector(50);
            vc3.RandomInitialization(0, 30);
            vc3.QuickSort(Pivot.END);
            Console.WriteLine(vc3);
            Console.WriteLine("*******************************\n*******************************");

        }
    }
}
