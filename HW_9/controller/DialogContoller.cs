using HW_9.entity;
using HW_9.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.controller
{
    class DialogContoller
    {
        static public void LoadMenuDialog()
        {

        }

        static public void WriteReportDialog(Menu menu)
        {
            MenuFileCotroller cotroller = new();
            CurrencyCollection curList = CurrencyService.ReadCurrency();

            Console.Write("Choose currency (EUR/USD): ");
            string temp = Console.ReadLine().ToUpper();
            KeyValuePair<string, double> currency = curList.GetCurrencyData(temp);

            cotroller.WriteReport(menu, currency);

        }
    }
}
