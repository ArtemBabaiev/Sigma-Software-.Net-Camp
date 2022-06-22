using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Task2
{
    class Task2Demo
    {
        public static void Start()
        {
            Task2.Matrix matrix = new(5, 5);
            matrix.NormalFill();
            matrix.PrintMatrix();
            Console.WriteLine("***********************************************");

            foreach (var item in matrix)
            {
                Console.WriteLine(item);
            }
        }
    }
}
