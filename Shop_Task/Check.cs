using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    static class Check
    {
        public static void PrintBuy(Buy buy)
        {
            Console.WriteLine(buy.ToString());
        }
        public static void PrintProduct(Product product)
        {
            Console.WriteLine(product.ToString());
        }
    }
}
