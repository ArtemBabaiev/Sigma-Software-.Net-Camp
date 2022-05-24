using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Software.HM_2.Task1
{
    class Product
    {
        private string name;
        protected double price;
        protected double weight;

        public Product():this(null, 0.0, 0.0)
        {
        }

        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public string Name { get => name; set => name = value; }
        public double Price { 
            get => price;

            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                price = value;
            }  
        }
        public double Weight { 
            get => weight;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                weight = value;
            }
        }


        public virtual void ChangePrice(double percentage)
        {
            Price = Price * (percentage / 100);
        }

        public override string ToString()
        {
            return $"name:{name}, price:{price}, weight:{weight}";
        }
        public void Parse(String str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            string[] vs = str.Split(", ");
            Name = vs[0];
            Price = Convert.ToDouble(vs[1]);
            Weight = Convert.ToDouble(vs[2]);
        }

        public override bool Equals(object obj)
        {
            Product product = (Product)obj;
            return this.Name == product.Name && this.Price == product.Price && this.Weight == product.Weight;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
