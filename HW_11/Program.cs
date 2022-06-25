using System;

namespace HW_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Task2.MyList<int> lst = new Task2.MyList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }
        }
    }
}
