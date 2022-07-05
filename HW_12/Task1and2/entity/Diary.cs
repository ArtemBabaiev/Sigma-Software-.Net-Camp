using HW_12.Task1.exceptions;
using HW_12.Task1.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Task1.entity
{
    internal class Diary:Product, ICreate<Diary>
    {
        #region fields
        private DateTime expireDate;
        #endregion

        #region constructors
        public Diary(): this(null, 0.0, 0.0, default)
        {
        }

        public Diary(string name, double price, double weight, DateTime expireDate) : base(name, price, weight)
        {
            this.ExpireDate = expireDate;
        }
        #endregion

        #region properties
        public DateTime ExpireDate { get => expireDate; set => expireDate = value; }
        public bool IsExpired
        {
            get
            {
                if (DateTime.Compare(DateTime.Now, expireDate)<=0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        #endregion

        #region ICreateImpl
        /// <summary>
        /// [0] - name
        /// [1] - price
        /// [2] - weight
        /// [3] - expire date
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Meat object</returns>
        public static new Diary CreateFrom(params string[] data)
        {
            if (data.Length == 4)
            {
                string name = data[0];
                double price, weight;
                DateTime dateTime;

                if (double.TryParse(data[1], out price) && double.TryParse(data[1], out weight)
                    && DateTime.TryParse(data[3].Replace("/", "."), out dateTime))
                {
                    return new Diary(name, price, weight, dateTime);
                }
            }
            throw new InvalidProductDataException();
        }
        #endregion

        #region object overrides
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString()[..^1] + $", {nameof(ExpireDate)}={ExpireDate.ToString("dd.MM.yyyy")}}}";
        }
        #endregion

    }
}
