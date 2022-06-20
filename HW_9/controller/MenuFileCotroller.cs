using HW_9.entity;
using HW_9.exceptions;
using HW_9.service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.controller
{
    class MenuFileCotroller
    {
        string prevProblemIngr = "";
        public Menu LoadMenu()
        {
            try
            {
                MenuFileService service = new MenuFileService();
                return service.ReadMenu();
            }
            catch (NoPriceInFileException e)
            {
                NoPriceHandler(e.Message);
                return LoadMenu();
            }
            catch (IncorrectPriceFileException e)
            {
                IncorrectPriceHandler(e.Message);
                return LoadMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default;
            }
        }

        private void NoPriceHandler(string name)
        {
            if (prevProblemIngr != name)
            {
                Console.WriteLine($"Add price for {name}");
                Console.Write("Press Enter:");
                Console.ReadLine();
            }
        }
        private void IncorrectPriceHandler(string name)
        {
            if (prevProblemIngr != name)
            {
                Console.WriteLine($"Correct price for {name}");
                Console.Write("Press Enter:");
                Console.ReadLine();
            }
        }
        
        public void WritePrice( Menu menu)
        {
            Currencies cur = Currencies.UAH;
            do
            {
                Console.Write("Choose currency (EUR/USD): ");
                string temp = Console.ReadLine().ToUpper();
                if (Enum.GetNames(typeof(Currencies)).Contains(temp))
                {
                    cur = (Currencies)Enum.Parse(typeof(Currencies), temp);
                    break;
                }
            } while (true);

            using (StreamWriter writer = File.CreateText(@"txtData/result.txt"))
            {
                double priceToWrite = menu.GetPriceOfRequiredIngridients();
                double course = 1;
                using (StreamReader reader = new StreamReader(@"txtData/Course.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.Contains(cur.ToString()))
                        {
                            course = double.Parse(line.Split(" - ")[1]);
                        }
                    }
                }
                writer.Write($"Cost of required ingredients\nCost - {Math.Round(priceToWrite * course, 2)} {cur.ToString()}");
            }
        }


    }
}
