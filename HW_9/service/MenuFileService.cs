using HW_9.entity;
using HW_9.exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_9.service
{
    class MenuFileService
    {
        public Menu ReadMenu()
        {
            try
            {
                Menu menu = new Menu();

                using (StreamReader reader = new StreamReader(@"txtData\Menu.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string dishString = ReadDishInfo(reader);
                        Dish dish = Dish.GetDishFromString(dishString);
                        GetPricesForDishIngridients(dish);
                        menu.AddDish(dish);
                    }
                }
                return menu;
            }
            catch (Exception e) 
            when(e is FileNotFoundException || 
                 e is DirectoryNotFoundException ||
                 e is NoPriceInFileException ||
                 e is IncorrectPriceFileException ||
                 e is IncompleteDishDataException ||
                 e is IncompleteIngridientDataException ||
                 e is IncorrectIngridientDataException)
            {
                throw;
            }
        }

        private string ReadDishInfo(StreamReader reader)
        {
            string dishInfo = "";
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line != "")
                {
                    dishInfo += line + "\n";
                }
                else
                {
                    break;
                }
            }
            return dishInfo[..^1];
        }

        private void GetPricesForDishIngridients(Dish dish)
        {
            foreach (var key in dish.MassOfIngridients.Keys)
            {
                using (StreamReader reader = new StreamReader(@"txtData\Prices.txt"))
                {
                    bool isFound = false;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.Contains(key.Name))
                        {
                            try
                            {
                                key.PriceOfKilo = double.Parse(line.Split("-")[1]);
                                isFound = true;
                            }
                            catch (FormatException)
                            {
                                throw new IncorrectPriceFileException(key.Name);
                            }
                        }
                    }
                    if (!isFound)
                    {
                       throw new NoPriceInFileException(key.Name);
                    }
                }
            }
        }
    }
}
