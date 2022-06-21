using HW_9.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.service
{
    class CurrencyService
    {
        static public CurrencyCollection ReadCurrency()
        {
            CurrencyCollection coll = new();
            using (StreamReader reader = new(@"txtData\Course.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] data = reader.ReadLine().Split(" - ");
                    string name = data[0];
                    double course = double.Parse(data[1]);
                    coll.AddCurrency(name, course);
                }
            }
            return coll;
        }
    }
}
