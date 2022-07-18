using HW_14.Task3.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task3.concrete_classes
{
    internal class FoodProduct: IFood
    {

        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public double Weight { get; protected set; }
        public DateTime ExpireDate { get; protected set; }

        public FoodProduct(): this("NaN", default, default, new DateTime())
        {
        }

        public FoodProduct(string name, double price, double weight, DateTime expireDate)
        {
            Name = name;
            Price = price;
            Weight = weight;
            ExpireDate = expireDate;
        }
    }
}
