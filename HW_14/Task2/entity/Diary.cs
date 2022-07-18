using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task2.entity
{
    [Serializable]
    public class Diary:Product
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
