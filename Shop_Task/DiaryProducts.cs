using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Task
{
    internal class DiaryProducts:Product
    {
        private DateTime expireDate;

        public DiaryProducts(): this(null, 0.0, 0.0, default)
        {
        }

        public DiaryProducts(string name, double price, double weight, DateTime expireDate) : base(name, price, weight)
        {
            this.ExpireDate = expireDate;
        }

        public DiaryProducts(Product product, DateTime expireDate) : base(product.Name, product.Price, product.Weight)
        {
            this.ExpireDate = expireDate;
        }

        public DateTime ExpireDate { get => expireDate; set => expireDate = value; }

        public override void ChangePrice(double percentage)
        {
            if (DateTime.Compare(ExpireDate, DateTime.Now) > 0)
            {
                Price *= percentage * 0.9;
            }
            else if (DateTime.Compare(ExpireDate, DateTime.Now) < 0)
            {
                Price *= 0;
            }
            else
            {
                Price *= 0.25 * percentage;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", expireDate: {expireDate.ToString("yyyy MM dd")}";
        }
    }
}
