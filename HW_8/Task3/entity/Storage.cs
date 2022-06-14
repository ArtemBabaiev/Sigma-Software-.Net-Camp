using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_8.Task3.entity
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

        #region properties
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
        #endregion

        #region hw 8 part
        /// <summary>
        /// Returns a list of products that exist in parameter <paramref name="a"/> 
        /// and not exist in parameter <paramref name="b"/>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static IEnumerable<Product> Difference(Storage a, Storage b)
        {
            List<Product> result = new List<Product>();
            foreach (Product item in a.allProducts)
            {
                //Contains<Product> використовує Equals відповідних класів
                if (!b.allProducts.Contains<Product>(item))
                {
                    result.Add(item);
                }
            }
            return result;
            //або
            //return a.allProducts.Except<Product>(b.allProducts);
        }
        /// <summary>
        /// Return list of products that exist in parameter <paramref name="a"/> 
        /// and in parameter <paramref name="b"/> simultaneously
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static IEnumerable<Product> Intersection(Storage a, Storage b)
        {
            List<Product> result = new List<Product>();
            foreach (Product item in a.allProducts)
            {
                if (b.allProducts.Contains<Product>(item))
                {
                    result.Add(item);
                }
            }
            return result;
            // або
            //return a.allProducts.Intersect(b.allProducts);

        }
        /// <summary>
        /// Returns list of unique products in parameter <paramref name="a"/> 
        /// and parameter <paramref name="b"/> united
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static IEnumerable<Product> UniqueUnion(Storage a, Storage b)
        {
            List<Product> uniqueA = a.allProducts.Distinct<Product>().ToList();
            List<Product> uniqueB = b.allProducts.Distinct<Product>().ToList();
            return uniqueA.Union<Product>(uniqueB);
        }
        #endregion

        #region old
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
        #endregion
    }

}
