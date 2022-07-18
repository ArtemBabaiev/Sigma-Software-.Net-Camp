using HW_14.Task3.enums;
using HW_14.Task3.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task3
{
    abstract class ProductFactory
    {
        public string factoryName;
        public abstract IProduct CreateIndustrialProduct(IndustrialProductEnum productEnum);
        public abstract IProduct CreateFoodProduct(FoodProductEnum productEnum);
    }
}
