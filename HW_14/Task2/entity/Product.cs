using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task2.entity
{
    [Serializable]
    public class Product
    {
        #region fields
        protected string name;
        protected double price;
        protected double weight;
        #endregion

        #region constructors
        public Product() : this(null, 0.0, 0.0)
        {
        }

        public Product(string name, double price, double weight)
        {
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }
        #endregion

        #region properties
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public double Weight { get => weight; set => weight = value; }

        
        #endregion

        #region object overrides
        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Weight)}={Weight.ToString()}}}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Product product &&
                   name == product.name &&
                   price == product.price &&
                   weight == product.weight;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, price, weight);
        }
        #endregion

    }
}
