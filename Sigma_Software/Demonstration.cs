using Sigma_Software.HM_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Software
{
    class Demonstration
    {
        public static void DemonstrateHomeWork3()
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
            Console.WriteLine("***********************************************************");
            mtr.SpiralFill();
            mtr.PrintMatrix();
            Console.WriteLine("***********************************************************");
            mtr.ReverseFill();
            mtr.PrintMatrix();
            Console.WriteLine("\n***********************************************************\n");



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
