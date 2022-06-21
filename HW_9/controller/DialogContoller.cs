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

        static public KeyValuePair<string, double> ChooseCurrencyDialog()
        {
            MenuFileCotroller cotroller = new();
            CurrencyCollection curList = CurrencyService.ReadCurrency();

            Console.Write("Choose currency (EUR/USD): ");
            string temp = Console.ReadLine().ToUpper();
            return  curList.GetCurrencyData(temp);


        }
    }
}
