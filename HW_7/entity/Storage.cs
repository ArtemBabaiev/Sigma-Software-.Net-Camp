using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_7.entity
{
    internal class Storage:IEnumerable
    {
        List<Product> allProducts;

        #region constructors
        public Storage()
        {
            this.AllProducts = new List<Product>();
        }

        public Storage(List<Product> allProducts)
        {
            this.AllProducts = allProducts;
        }
        #endregion


        protected List<Product> AllProducts
        {
            get => allProducts;
            set
            {
                foreach (var item in value)
                {
                    if (item is not Product)
                    {
                        throw new ArgumentException();
                    }
                }
                allProducts = value;
            }
        }


        public List<Meat> GetAllMearProducts()
        {
            List<Meat> result = new List<Meat>();
            foreach (var item in AllProducts)
            {
                if (item is Meat)
                {
                    result.Add((Meat)item);
                }
            }
            return result;
        }
        
        public void ChangeAllPricesByPercentage(double percentage)
        {
            foreach (var item in AllProducts)
            {
                switch (item)
                {
                    case Meat m:
                        m.ChangePrice(percentage);
                        break;
                    case DiaryProduct d:
                        d.ChangePrice(percentage);
                        break;
                    case Product p:
                        p.ChangePrice(percentage);
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddProduct(Product product)
        {
            AllProducts.Add(product);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)AllProducts).GetEnumerator();
        }

        public Product this[int i]
        {
            get 
            {
                if (i >= 0 && i < allProducts.Count)
                {
                    return AllProducts[i];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set 
            {
                if (i >= 0 && i < allProducts.Count)
                {
                    if (value is Product)
                    {
                        AllProducts[i] = value;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();

                }

            }
        }
    }

}
