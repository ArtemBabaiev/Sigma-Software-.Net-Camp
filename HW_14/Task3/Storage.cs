using HW_14.Task3.concrete_classes;
using HW_14.Task3.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task3
{
    public class Storage
    {
        #region Singleton part
        private static Storage instance;
        public static Storage getInstance(List<IProduct> allProducts)
        {
            if (instance == null)
                instance = new Storage(new List<IProduct>(allProducts));
            return instance;
        }
        private List<IProduct> allProducts;
        private Storage(List<IProduct> allProducts)
        {
            this.allProducts = allProducts;
        }

        #endregion

        #region WorkWithStorage


        public void AddProducts(IEnumerable<IProduct> products)
        {
            if (products is not null)
            {
                allProducts.AddRange(products);
            }
            throw new ArgumentNullException();
        }

        public List<IProduct> GetAllProducts()
        {
            return allProducts;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public List<IProduct> GetProductsByType(Type type)
        {
            List<IProduct> result = new();
            foreach (var item in allProducts)
            {
                if (item.GetType() == type)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        #endregion

    }
}
