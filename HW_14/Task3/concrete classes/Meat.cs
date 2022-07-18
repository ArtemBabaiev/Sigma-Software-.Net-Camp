using HW_14.Task3.enums;
using HW_14.Task3.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task3.concrete_classes
{
    class Meat:FoodProduct
    {
        public MeatCategory Category { get; protected set; }
        public MeatType MType { get; protected set; }

        public Meat(): this("NaN", default, default, new DateTime(), default, default)
        {
        }

        public Meat(string name, double price, double weight, DateTime expireDate, MeatCategory category, MeatType type)
              :base(name, price, weight, expireDate)
        {
            Category = category;
            MType = type;
        }
    }
}
