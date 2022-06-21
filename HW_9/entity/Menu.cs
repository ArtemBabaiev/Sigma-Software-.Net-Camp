using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.entity
{
    class Menu
    {
        #region fields
        private List<Dish> dishes;
        #endregion

        #region constructors
        public Menu():this(new List<Dish>())
        {
        }

        public Menu(List<Dish> dishes)
        {
            this.Dishes = dishes;
        }
        #endregion

        #region properties
        public List<Dish> Dishes 
        { 
            get => dishes;
            protected set
            {
                dishes = value ?? throw new ArgumentNullException(nameof(dishes));
            }
        }
        #endregion

        #region methods
        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
        }

        public double GetPriceOfRequiredIngridients()
        {
            double result = 0;
            foreach (var dish in dishes)
            {
                foreach (var item in dish.MassOfIngridients)
                {
                    result += item.Key.PriceOfKilo * item.Value/1000.0;
                }
            }
            return result;
        }

        public string FormReport(KeyValuePair<string, double> currency)
        {
            string report = $"Total price: {Math.Round(GetPriceOfRequiredIngridients() * currency.Value, 2)} {currency.Key}\n";
            Dictionary<Ingredient, double> required = GetIngredietsAndMasses();

            foreach (var item in required)
            {
                report += $"Ingridient: {item.Key.Name}, Required: {item.Value} gramms\n";
            }
            
            return report;

        }
        public Dictionary<Ingredient, double> GetIngredietsAndMasses()
        {
            Dictionary<Ingredient, double> dict = new();
            foreach (var dish in dishes)
            {
                foreach (var item in dish.MassOfIngridients)
                {
                    if (!dict.ContainsKey(item.Key))
                    {
                        dict.Add(item.Key, item.Value);
                    }
                    else
                    {
                        dict[item.Key] += item.Value;
                    }
                }
            }
            return dict;
        }
        #endregion

        #region overrides
        public override string ToString()
        {
            string result = "[";
            foreach (var item in dishes)
            {
                result += $"{item.Name}, ";
            }
            result = result[..^2] + "]";
            return $"{{{nameof(Dishes)}={result}}}";
        }
        #endregion
    }
}
