using HW_14.Task2.entity;
using HW_14.Task2.serialisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task2
{
    internal class Demo
    {
        public static void Start()
        {
            Storage storage = new(new List<Product>()
            {
                new Product("name", 15, 15),
                new Product("name", 15, 15),
                new Product("name", 15, 15),
                new Product("name", 15, 15),
                new Product("name", 15, 15)
            });
            Console.WriteLine("JSON");
            Console.WriteLine(StorageSerialisation.JsonSerialisation(storage));
            Storage stJson = StorageSerialisation.JsonDeserialisation();
            Console.WriteLine("XML");
            Console.WriteLine(StorageSerialisation.XMLSerialisation(storage));
            Storage stXml = StorageSerialisation.XMLDeserialisation();
            Console.WriteLine("Binnary");
            Console.WriteLine(StorageSerialisation.BinnarySerialisation(storage));
            Storage stBin = StorageSerialisation.BinnaryDeserialisation();

        }

    }
}
