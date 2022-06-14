using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8.Task2
{
    class Task2Demo
    {
        public static void Start()
        {
            var web = new WebStatHandler(@"Task2/txtData/stats.txt");
            Console.WriteLine(web.GetMostPopularDayOfWeek());
            Console.WriteLine(web.GetSitesVisitByIp("139.18.150.126"));
            Console.WriteLine(web.GetMostPopularTime());
            Console.WriteLine(web.GetMostPopularTimeInDay("sunday"));
        }
    }
}
