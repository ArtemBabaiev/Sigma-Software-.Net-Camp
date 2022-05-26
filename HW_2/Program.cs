using HW_2.Task1;
using HW_2.Task2;
using System;

namespace HW_2
{
    class Program
    {
        static void Main(string[] args)
        {
            DemonstrateTask1();
            Console.WriteLine("**************************************************\n**************************************************");
            DemonstrateTask2();
        }
        static void DemonstrateTask1()
        {
            Storage storage = new Storage();
            storage.FillStorage();
        }
        static void DemonstrateTask2()
        {
            Matrix mtr = new Matrix(5, 5);
            try
            {
                mtr.DiagonalFill();
                mtr.PrintMatrix();
                Console.WriteLine("***********************************************************");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("***********************************************************");
            mtr.SpiralFill();
            mtr.PrintMatrix();
            Console.WriteLine("***********************************************************");
            mtr.ReverseFill();
            mtr.PrintMatrix();
            Console.WriteLine("\n***********************************************************\n");
        }
        
    }
}
