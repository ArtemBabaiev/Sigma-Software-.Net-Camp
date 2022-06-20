using HW_9.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.entity
{
    class Dish
    {
        #region fields
        private string name;
        private Dictionary<Ingredient, double> massOfIngridients;
        #endregion

        #region constructors
        public Dish():this("", new Dictionary<Ingredient, double>())
        {
        }

        public Dish(string name, Dictionary<Ingredient, double> massOfIngridients)
        {
            this.Name = name;
            this.MassOfIngridients = massOfIngridients;
        }
        #endregion

        #region properties
        public string Name 
        { 
            get => name; 
            set => name = value ?? throw new ArgumentNullException(nameof(value)); 
        }
        public Dictionary<Ingredient, double> MassOfIngridients 
        { 
            get => massOfIngridients;
            protected set => massOfIngridients = value ?? throw new ArgumentNullException(nameof(value)); 
        }
        #endregion

        #region methods
        public int GetIngridientsQuantity()
        {
            return massOfIngridients.Count;
        }
        #endregion

        #region static methods
        /// <summary>
        /// Returns a Dish object from string that has file format
        /// </summary>
        /// <param name="menuAsString"></param>
        /// <returns></returns>
        public static Dish GetDishFromString(string dishAsString)
        {
            var dishLines = dishAsString.Split("\n");
            if (dishLines.Length < 2)
            {
                throw new IncompleteDishDataException();
            }
            string dishName = dishLines[0];
            Dictionary<Ingredient, double> ingridients = new Dictionary<Ingredient, double>();
            for (int i = 1; i < dishLines.Length; i++)
            {
                try
                {
                    var ingrData = dishLines[i].Split(",");
                    var temp = new Ingredient(ingrData[0]);
                    if (!ingridients.ContainsKey(temp))
                    {
                        ingridients.Add(temp, double.Parse(ingrData[1]));
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IncompleteIngridientDataException();
                }
                catch (FormatException)
                {
                    throw new IncorrectIngridientDataException();
                }
            }

            return new Dish(dishName, ingridients);
        }
        #endregion

        #region overrides
        public override bool Equals(object obj)
        {
            if (obj is Dish dish && this.name == dish.name && this.GetIngridientsQuantity() == dish.GetIngridientsQuantity())
            {
                // check keys are the same
                foreach (var key in this.massOfIngridients.Keys)
                {
                    if (!dish.massOfIngridients.ContainsKey(key))
                    {
                        return false;
                    }
                }
                // check values are the same
                foreach (var key in this.massOfIngridients.Keys)
                {
                    if (!this.massOfIngridients[key].Equals(dish.massOfIngridients[key]))
                    {
                        return false;
                    }
                }
                return true;    
            }
            else
            {
                return false;
            }

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, massOfIngridients);
        }

        public override string ToString()
        {
            string ingrStr = "[";
            foreach (var item in massOfIngridients)
            {
                ingrStr += $"({item.Key.Name}-{item.Value})";
            }
            ingrStr = ingrStr.Replace(")(", "), (") + "]";
            return $"{{{nameof(Name)}={Name}, {nameof(MassOfIngridients)}={ingrStr}}}";
        }
        #endregion

    }
}
