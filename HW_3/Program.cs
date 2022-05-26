using System;

namespace HW_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix mtr = new Matrix(5, 5);

            try
            {
                mtr.DiagonalFill(Direction.DOWN);
                mtr.PrintMatrix();
                Console.WriteLine("***********************************************************");
                mtr.DiagonalFill(Direction.RIGHT);
                mtr.PrintMatrix();
                Console.WriteLine("***********************************************************");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            



            Vector vector = new Vector(new int[] { 1, 1, 1, 2, 1, 1, 2, 2, 3, 3, 3, 3, 3 });
            vector.MyReverse();
            Console.WriteLine("Reversed: " + vector);
            Console.WriteLine("Longest subsequence");
            foreach (var item in vector.LongestSubSequence())
            {
                Console.WriteLine(item);
            }

            Vector vc1 = new Vector(6);
            vc1.ShuffleInitialization();
            Console.WriteLine("Shuffle init: " + vc1);
        }
    }
}
