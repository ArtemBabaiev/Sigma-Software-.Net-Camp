using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7.entity
{
    internal class Meat : Product
    {
        MeatType type;
        MeatCategory category;

        internal MeatCategory Category { get => category; set => category = value; }
        internal MeatType Type { get => type; set => type = value; }

        public Meat() : this(null, 0.0, 0.0, default, default) { }

        public Meat(string name, double price, double weight, MeatType type, MeatCategory category) : base(name, price, weight)
        {
            this.Type = type;
            this.Category = category;
        }

        public Meat(Product product, MeatType type, MeatCategory category) : base(product.Name, product.Price, product.Weight)
        {
            this.Type = type;
            this.Category = category;
        }
        
        public override void ChangePrice(double percentage)
        {
            double k;
            switch (Category)
            {
                case MeatCategory.HIGH:
                    k = 0.9;
                    break;
                case MeatCategory.FIRST:
                    k = 0.8;
                    break;
                case MeatCategory.SECOND:
                    k = 0.7;
                    break;
                default:
                    k = 1;
                    break;
            }

            Price = Price * percentage * k;
        }


        public override string ToString()
        {
            return base.ToString() + $", type: {type}, category: {category}";
        }

        public override bool Equals(object obj)
        {
            Meat meat = (Meat)obj;
            
            return base.Equals(obj) && this.Category == meat.Category && this.Type == meat.Type;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
