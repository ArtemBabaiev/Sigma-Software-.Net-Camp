using HW_12.Task1.exceptions;
using HW_12.Task1.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Task1.entity
{
    public class Product : ICreate<Product>
    {
        #region fields
        protected readonly string id;
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
            this.id = Guid.NewGuid().ToString();
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }
        #endregion

        #region properties
        public string Id => id;

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public double Weight { get => weight; set => weight = value; }
        #endregion

        #region ICreateImpl
        /// <summary>
        /// [0] - name
        /// [1] - price
        /// [2] - weight
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Meat object</returns>
        public static Product CreateFrom(params string[] data)
        {
            if (data.Length == 3)
            {
                string name;
                double price, weight;

                if (double.TryParse(data[1], out price) && double.TryParse(data[2], out weight))
                {
                    name = data[0];
                    return new Product(name, price, weight);
                }
            }
            throw new InvalidProductDataException();
        }
        #endregion

        #region object overrides
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Weight)}={Weight.ToString()}}}";
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   id == product.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }
        #endregion

    }
}
