using HW_14.Task3.concrete_classes;
using HW_14.Task3.enums;
using HW_14.Task3.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task3.factories
{
    class FoodProductFactory : ProductFactory
    {
        public override IProduct CreateFoodProduct(FoodProductEnum productEnum)
        {
            switch (productEnum)
            {
                case FoodProductEnum.DIARY:
                    return new Diary();
                case FoodProductEnum.MEAT:
                    return new Meat();
                case FoodProductEnum.DEFAULT:
                    return new FoodProduct();
            }
            return new FoodProduct();
        }

        public override IProduct CreateIndustrialProduct(IndustrialProductEnum productEnum)
        {
            return null;
        }
    }
}
