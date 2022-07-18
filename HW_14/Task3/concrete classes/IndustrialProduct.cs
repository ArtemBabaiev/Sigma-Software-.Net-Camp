using HW_14.Task3.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task3.concrete_classes
{
    class IndustrialProduct : IIndustrial
    {
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public double Weight { get; protected set; }
        public Dictionary<string, string> Characteristic { get; protected set; }

        public IndustrialProduct(): this("NaN", default, default, new Dictionary<string, string>())
        {
        }

        public IndustrialProduct(string name, double price, double weight, Dictionary<string, string> characteristic)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Characteristic = characteristic;
        }
    }
}
