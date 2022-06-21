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
        
        public void WriteReport(Menu menu, KeyValuePair<string, double> currency) 
        {
            string report = menu.FormReport(currency);
            using (StreamWriter writer = File.CreateText(@"txtData\result.txt"))
            {
                writer.Write(report);
            }
        }



    }
}
