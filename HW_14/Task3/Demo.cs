using HW_14.Task3.factories;
using HW_14.Task3.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task3
{
    internal class Demo
    {
        public static void Start()
        {
            ProductFactory factory0 = new FoodProductFactory();
            ProductFactory factory1 = new IndustrialProductFactory();
            _ = factory0.CreateIndustrialProduct(Task3.enums.IndustrialProductEnum.EQUIPMENT);
            _ = factory1.CreateFoodProduct(Task3.enums.FoodProductEnum.DIARY);
            List<IProduct> products = new List<IProduct>()
            {
                factory1.CreateFoodProduct(Task3.enums.FoodProductEnum.DIARY),
                factory1.CreateFoodProduct(Task3.enums.FoodProductEnum.DIARY),
                factory1.CreateFoodProduct(Task3.enums.FoodProductEnum.DIARY),
                factory1.CreateFoodProduct(Task3.enums.FoodProductEnum.DIARY),
                factory1.CreateFoodProduct(Task3.enums.FoodProductEnum.DIARY),
                factory1.CreateFoodProduct(Task3.enums.FoodProductEnum.DIARY),
            };
            Storage storage = Storage.getInstance(products);
        }
    }
}
