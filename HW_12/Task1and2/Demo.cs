using HW_12.Task1.entity;
using HW_12.Task1.fillers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Task1
{
    class Demo
    {
        public static void Start()
        {
            Storage storage = Storage.CreateFrom(StorageFileReader.Read());

            //Event
            storage.OnAddingExpired += Storage_OnAddingExpired;
            storage.AddProduct(new Diary("name", 15.5, 16.5, new DateTime(2002, 07, 18)));

            Console.WriteLine("".PadLeft(25, '*'));
            //Пошук за певною ознакою
            foreach (var item in storage.FindBy(prod => prod.Price > 17))
            {
                Console.WriteLine(item);
            }
        }

        private static void Storage_OnAddingExpired(Storage sender, eventArgs.ExpiredEventArgs e)
        {
            Console.WriteLine($"Event message: {e.Message}");
            Console.WriteLine($"Do you wish to remove all expired products? ");
            string temp = Console.ReadLine();
            if (temp == "y" || temp == "Y")
            {
                using (StreamWriter writer = File.CreateText(@"Task1/txtData/utilization.txt"))
                {
                    foreach (var item in sender)
                    {
                        if (item is Diary diary && diary.IsExpired)
                        {
                            writer.WriteLine(diary.ToString());
                        }
                    }
                }
                sender.RemoveExpired();

            }
        }
    }
}
