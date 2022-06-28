using HW_12.Task1.enums;
using HW_12.Task1.exceptions;
using HW_12.Task1.interfaces;
using HW_12.Task1.validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Task1.entity
{
    public class Meat : Product, ICreate<Meat>
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

        #region ICreateImpl
        /// <summary>
        /// [0] - name
        /// [1] - price
        /// [2] - weight
        /// [3] - type
        /// [4] - category
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Meat object</returns>
        public static new Meat CreateFrom(params string[] data)
        {
            if (data.Length == 5)
            {
                string name = data[0];
                double price, weight;
                MeatType type;
                MeatCategory category;

                if (double.TryParse(data[1], out price) && double.TryParse(data[1], out weight)
                    && Validation.IsStringEnumOf(data[3], typeof(MeatType))
                    && Validation.IsStringEnumOf(data[4], typeof(MeatCategory)))
                {
                    type = (MeatType)Enum.Parse(typeof(MeatType), data[3].ToUpper());
                    category = (MeatCategory)Enum.Parse(typeof(MeatCategory), data[4].ToUpper());
                    return new Meat(name, price, weight, type, category);
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
            return base.ToString()[..^1] + $", {nameof(Category)}={Category.ToString()}, {nameof(Type)}={Type.ToString()}}}";
        }
        #endregion
    }
}
