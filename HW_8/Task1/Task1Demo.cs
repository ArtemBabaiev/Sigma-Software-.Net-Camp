using HW_8.Task1.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8.Task1
{
    class Task1Demo
    {
        public static bool Start()
        {
            try
            {
                Report report1 = new Report();
                Report report2 = new Report();
                report1.AddAppartmentToReport(
                    new Appartment() { Number = 1, OwnerName = "name1" }
                    );
                report1.AddAppartmentToReport(
                    new Appartment() { Number = 2, OwnerName = "name2" }
                    );
                report1.AddAppartmentToReport(
                    new Appartment() { Number = 3, OwnerName = "name4" }
                    );

                report2.AddAppartmentToReport(
                    new Appartment() { Number = 1, OwnerName = "name1" }
                    );
                report2.AddAppartmentToReport(
                    new Appartment() { Number = 4, OwnerName = "name2" }
                    );
                report2.AddAppartmentToReport(
                    new Appartment() { Number = 3, OwnerName = "name4" }
                    );
                Console.WriteLine(report1+report2);
                Console.WriteLine("*************************");
                Console.WriteLine(report1 - report2);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
