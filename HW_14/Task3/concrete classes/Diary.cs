using HW_14.Task3.enums;
using HW_14.Task3.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task3.concrete_classes
{
    internal class Diary:FoodProduct
    {
        public DiaryType DType { get; protected set; }

        public Diary() : this("NaN", default, default, new DateTime(), default)
        {
        }

        public Diary(string name, double price, double weight, DateTime expireDate, DiaryType type)
              : base(name, price, weight, expireDate)
        {
            DType = type;
        }
    }
}
