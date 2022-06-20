using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.entity
{
    class Ingredient
    {
        #region fields
        private string name;
        private double priceOfKilo;
        #endregion

        #region constructors
        public Ingredient() : this("")
        {
        }

        public Ingredient(string name):this(name, default)
        {
        }

        public Ingredient(string name, double price)
        {
            this.Name = name;
            this.PriceOfKilo = price;
        }
        #endregion

        #region properties
        public string Name 
        { 
            get => name; 
            set => name = value ?? throw new ArgumentNullException(nameof(value)); 
        }
        public double PriceOfKilo { get => priceOfKilo; set => priceOfKilo = value; }
        #endregion

        #region overrides
        public override bool Equals(object obj)
        {
            return obj is Ingredient ingredient &&
                   Name == ingredient.Name &&
                   PriceOfKilo == ingredient.PriceOfKilo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, PriceOfKilo);
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(PriceOfKilo)}={PriceOfKilo.ToString()}}}";
        }

        #endregion
    }
}
