using System;

namespace HW_1_and_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix mtr = new Matrix(5, 5);

            try
            {
                mtr.DiagonalFill();
                mtr.PrintMatrix();
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

            Storage storage = new Storage();
            storage.FillStorage();


        }
    }
}
