using HW_7.entity;
using HW_7.controller_services;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HW_7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            StorageFileFillerController controller = new();
                        Storage storage = controller.FillStorage(@"textFiles/StorageData.txt");
                        foreach (var item in storage)
                        {
                            Console.WriteLine(item);
                        }*/
            RepairStorageController rp = new();
            rp.RepairFromLogs(@"log.txt", new DateTime(2002,07,18));

        }
    }
}
