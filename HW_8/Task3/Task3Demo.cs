using HW_8.Task3.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8.Task3
{
    class Task3Demo
    {
        public static void Start()
        {
            Storage s1 = new Storage();
            Storage s2 = new Storage();
            s1.AddProduct(new Product("name1", 15, 15));
            s1.AddProduct(new Product("name2", 15, 15));
            s1.AddProduct(new Product("name3", 15, 15));
            s2.AddProduct(new Product("name1", 15, 15));
            s2.AddProduct(new Product("name3", 15, 15));
            s2.AddProduct(new Product("name4", 15, 15));
            Console.WriteLine("Uniquw union");
            foreach (var item in Storage.UniqueUnion(s1, s2))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Difference");
            foreach (var item in Storage.Difference(s1, s2))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Intersection");
            foreach (var item in Storage.Intersection(s1, s2))
            {
                Console.WriteLine(item);
            }
        }

    }
}
