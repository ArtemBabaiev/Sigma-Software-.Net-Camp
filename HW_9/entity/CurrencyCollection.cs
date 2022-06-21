using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.entity
{
    class CurrencyCollection
    {
        private Dictionary<string, double> courses;

        public CurrencyCollection()
        {
            courses = new Dictionary<string, double>();
        }

        public void AddCurrency(string name, double course)
        {
            if (!courses.ContainsKey(name))
            {
                courses.Add(name, course);
            }
            else
            {
                courses[name] = course;
            }

        }

        public KeyValuePair<string, double> GetCurrencyData(string currencyName)
        {
            foreach (var item in courses)
            {
                if (item.Key == currencyName)
                {
                    return item;
                }
            }

            return new KeyValuePair<string, double>("UAH", 1);
        }
    }
}
