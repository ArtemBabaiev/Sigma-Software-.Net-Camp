using HW_14.Task3.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task2.entity
{
    [Serializable]
    public class Meat : Product
    {
        #region fields
        MeatType type;
        MeatCategory category;
        #endregion

        #region constructors
        public Meat() : this(null, 0.0, 0.0, default, default) { }

        public Meat(string name, double price, double weight, MeatType type, MeatCategory category) : base(name, price, weight)
        {
            this.Type = type;
            this.Category = category;
        }
        #endregion

        #region properties
        public MeatCategory Category { get => category; set => category = value; }
        public MeatType Type { get => type; set => type = value; }

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
            return base.ToString()[..^1] + $", {nameof(Category)}={Category.ToString()}, {nameof(Type)}={Type.ToString()}}}";
        }
        #endregion
    }
}
