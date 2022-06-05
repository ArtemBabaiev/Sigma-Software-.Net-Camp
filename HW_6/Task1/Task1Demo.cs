using HW_6.Task1.controller;
using HW_6.Task1.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6.Task1
{
    class Task1Demo
    {
        public static void Start()
        {
            try
            {
                FileController rpc = new FileController();
                Report rp = rpc.FillReportFromFile(@"Task1/txtData/ReportData.txt");

                rpc.WriteAppartmentInfoToFile(rp.Appartments[0]);
                rpc.WriteReportToFile(rp, @"ResultReport.txt");
                rp.EnergyCost = 100;

                Console.WriteLine("**************LARGEST DEBT**************");
                Console.WriteLine(rp.getOwnerWithLargestDebt());

                Console.WriteLine("**************NO USAGE**************");
                foreach (var item in rp.GetAppartmentWithNoUsage())
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("**************Час у днях після останнього зняття показів**************");
                Console.WriteLine(rp.Appartments[0].GetDayQuantityAfterLastRead());

                Console.WriteLine("**************Скільки треба заплатити квартирі**************");
                Console.WriteLine(rp.Appartments[0].GetExpenses(100));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
