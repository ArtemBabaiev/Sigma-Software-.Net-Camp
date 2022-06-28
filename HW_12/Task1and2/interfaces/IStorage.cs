using HW_12.Task1.entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Task1.interfaces
{
    interface IStorage
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(string id);
        public List<Product> GetProductsByType(Type type);

        public void AddProduct(Product product);
        public void AddProducts(IEnumerable<Product> products);

        public void RemoveProductById(string id);
        public void RemoveExpired();
    }
}
