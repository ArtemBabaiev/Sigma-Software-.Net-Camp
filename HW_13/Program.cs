using HW_13.entities;
using HW_13.enums;
using HW_13.generators;

namespace HW_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*PersonGenerator generator = new();
            List<entities.Person> people = generator.Generate();

            foreach (var item in people)
            {
                Console.WriteLine(item);
            }*/

            StationWorkProcess station = new(new()
            {
                new entities.CashRegister(1, new(0,1)),
                new entities.CashRegister(2, new(0,2)),
            });

            Console.WriteLine(station.StartWork().ToString());


            /*PriorityQueue<string, int> queue = new();
            *//*queue.Enqueue("name1", 0);
            queue.Enqueue("name2", 0);
            queue.Enqueue("name3", 0);
            queue.Enqueue("name4", 0);*//*
            Console.WriteLine(queue.Peek());*/
            Console.WriteLine(bool.Parse("false"));

        }
    }
}