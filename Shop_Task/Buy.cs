using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Buy
    {
        private List<Product>  productList;
        private int quantity;

        private double totalWeight;
        private double totalPrice;

        public Buy()
        {
            TotalPrice = 0;
            TotalWeight = 0;
            Quantity = 0;
            productList = new List<Product>();
        }

        public Buy(List<Product> productList)
        {
            Quantity = productList.Count;
            TotalPrice = 0;
            TotalWeight = 0;
            this.ProductList = productList;
            
            foreach (var item in productList)
            {
                TotalPrice+=item.Price;
                TotalWeight+=item.Weight;
            }
        }

        public int Quantity { get => quantity; set => quantity = value; }
        public double TotalWeight { get => totalWeight; set => totalWeight = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        internal List<Product> ProductList { get => productList; set => productList = value; }
    
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            ProductList.Add(product);
        }

        public override string ToString()
        {
            string result = $"totalPrice: {totalPrice}, totalWeight: {totalWeight}, quantity: {quantity}, productList:[";
            for (int i = 0; i < productList.Count; i++)
            {
                result += productList[i].Name;
                if (i != productList.Count-1)
                {
                    result += ", ";
                }
                else
                {
                    result += "]";
                }
            }
            
            return result;
        }
    }
}
