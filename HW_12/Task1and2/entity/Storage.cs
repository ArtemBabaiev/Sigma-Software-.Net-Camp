using HW_12.Task1.eventArgs;
using HW_12.Task1.exceptions;
using HW_12.Task1.interfaces;
using HW_12.Task1.validators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_12.Task1.entity
{
    internal class Storage : IEnumerable, IStorage, ICreate<Storage>
    {
        List<Product> allProducts;

        #region HW 12 part TASK1 and TASK2
        //Присвоєння делегату демонструється у класі Task1.Demo
        //Task1
        public delegate void ExpiredHandler(Storage sender, ExpiredEventArgs e);
        public event ExpiredHandler OnAddingExpired;

        public void AddProduct(Product product)
        {
            if (product is not null)
            {
                if (product is Diary diary && diary.IsExpired)
                {
                    OnAddingExpired?.Invoke(this, new($"Trying to add expired product {diary.Name}", diary));
                }
                else
                {
                    allProducts.Add(product);
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        //Task2
        public IEnumerable<Product> FindBy(Func<Product, bool> func)
        {
            return allProducts.Where(func);
        }
        #endregion

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
        private List<Product> AllProducts
        {
            get => allProducts;
        }
        #endregion

        #region IStorageImpl


        public void AddProducts(IEnumerable<Product> products)
        {
            if (products is not null)
            {
                allProducts.AddRange(products);
            }
            throw new ArgumentNullException();
        }

        public List<Product> GetAllProducts()
        {
            return allProducts;
        }


        public Product GetProductById(string id)
        {
            return allProducts.Find(prod => prod.Id == id);
        }

        public List<Product> GetProductsByType(Type type)
        {
            List<Product> result = new();
            foreach (var item in allProducts)
            {
                if (item.GetType() == type)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public void RemoveExpired()
        {
            allProducts.RemoveAll(prod => prod is Diary diary && diary.IsExpired);
        }

        public void RemoveProductById(string id)
        {
            allProducts.RemoveAll(prod => prod.Id == id);
        }
        #endregion

        #region ICreateImpl
        /// <summary>
        /// each string represents separate product
        /// </summary>
        /// <param name="data"></param>
        /// <returns>new instance of Storage</returns>
        public static Storage CreateFrom(params string[] data)
        {
            List<Product> products = new();
            foreach (var item in data)
            {
                if (!Validation.IsValidLine(item))
                {
                    continue;
                }
                string[] prodData = item.Split(" ");
                try
                {
                    switch (prodData[0].ToLower())
                    {
                        case "product":
                            products.Add(Product.CreateFrom(prodData[1..]));
                            break;
                        case "diary":
                            products.Add(Diary.CreateFrom(prodData[1..]));
                            break;
                        case "meat":
                            products.Add(Meat.CreateFrom(prodData[1..]));
                            break;
                        default:
                            break;
                    }

                }
                catch (InvalidProductDataException)
                {
                    Console.WriteLine($"Invalid line: {item}");
                }
            }
            return new Storage(products);
        }
        #endregion

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)allProducts).GetEnumerator();
        }
    }

}
