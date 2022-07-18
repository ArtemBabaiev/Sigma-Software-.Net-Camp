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
    internal class IndustrialProductFactory : ProductFactory
    {
        public override IProduct CreateFoodProduct(FoodProductEnum productEnum)
        {
            return null;
        }

        public override IProduct CreateIndustrialProduct(IndustrialProductEnum productEnum)
        {
            switch (productEnum)
            {
                case IndustrialProductEnum.EQUIPMENT:
                    return new Equipment();
                case IndustrialProductEnum.RAW_MATERIALS://сировина
                    return new RawMaterial();
                case IndustrialProductEnum.DEFAULT:
                    return new IndustrialProduct();
            }
            return new IndustrialProduct();
        }
    }
}
