using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_14.Task2.entity
{
    [Serializable]
    public class Storage
    {
        List<Product> allProducts;

        #region constructors
        public Storage()
        {
            this.allProducts = new List<Product>();
        }

        public Storage(List<Product> allProducts)
        {
            this.allProducts = allProducts;
        }
        #endregion

        #region properties
        public List<Product> AllProducts
        {
            get => allProducts;
        }
        #endregion
        public Product this[int i]
        {
            get { return i >= 0 && i < allProducts.Count ? allProducts[i] : throw new ArgumentException(); }
            set
            {
                if (i >= 0 && i < allProducts.Count)
                {
                    allProducts[i] = value;
                }
                else
                {
                    throw new ArgumentException(); allProducts[i] = value;
                }
            }
        }

    }

}
