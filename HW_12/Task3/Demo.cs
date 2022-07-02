using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Task3
{
    class Demo
    {
        public static void Start()
        {
            Console.WriteLine(Calculator.Evaluate(ExpressionTranlator.PolishFormOf("3 + 4 * 2 / sin ( 1 - 5 ) ^ 2"))); 
        }
    }
}
