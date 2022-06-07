using HW_7.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_7.controller_services
{
    class StorageCLIFillerService
    {

        public Storage FillStorageDialog()
        {
            Storage storage = new Storage();
            int numberToAdd;
            //цикл на кількість елементів
            do
            {
                Console.Write("How many elements to add: ");
                string temp = Console.ReadLine();
                if (Regex.IsMatch(temp, @"[0-9]{1,}"))
                {
                    numberToAdd = int.Parse(temp);
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            } while (true);
            
            for (int i = 0; i < numberToAdd; i++)
            {
                do
                {
                    Console.Write("Choose product type\n1 - Diary Product\n2 - Meat\n3 - Product\nAnswer(1/2/3): ");
                    string temp = Console.ReadLine();
                    if (Regex.IsMatch(temp, @"[123]"))
                    {
                        switch (temp)
                        {
                            case "1":
                                storage.AddProduct(CreateDiaryProductDialog());
                                break;
                            case "2":
                                storage.AddProduct(CreateMeatDialog());
                                break;
                            case "3":
                                storage.AddProduct(CreateProductDialog());
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine("\nProduct succesfully added\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("!!!Incorrect input!!!");
                    }
                } while (true);
            }
            return storage;
        }

        private Product CreateDiaryProductDialog()
        {
            Product product = CreateProductDialog();
            DateTime time;
            do
            {
                Console.WriteLine("Input date of expire\nInput(dd.mm.yyyy): ");
                string edTemp = Console.ReadLine();
                if (Regex.IsMatch(edTemp, @"\d{2}.\d{2}.\d{4}"))
                {
                    if (DateTime.TryParse(edTemp, out time))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("!!!Entered data doenst exist!!!");
                    }
                }
                else
                {
                    Console.WriteLine("!!!Invalid date format!!!");
                }
            } while (true);

            return new DiaryProduct(product, time);

        }

        private Product CreateMeatDialog()
        {
            Product product = CreateProductDialog();
            MeatType type;
            MeatCategory category;

            do
            {
                Console.Write("Choose meat type\n1 - MUTTON\n2 - VEAL\n3 - PORK\n4 - CHICKEN\nAnswer(word): ");
                string temp = Console.ReadLine().ToUpper();
                if (Enum.GetNames(typeof(MeatType)).Contains(temp))
                {
                    type = (MeatType)Enum.Parse(typeof(MeatType), temp);
                    break;
                }
                else
                {
                    Console.WriteLine("!!!Entered meat type doesnt exist!!!");
                }
            } while (true);

            do
            {
                Console.Write("Choose meat category\n1 - HIGH\n2 - FIRST\n3 - SECOND\nAnswer(word): ");
                string temp = Console.ReadLine().ToUpper();
                if (Enum.GetNames(typeof(MeatCategory)).Contains(temp))
                {
                    category = (MeatCategory)Enum.Parse(typeof(MeatCategory), temp);
                    break;
                }
                else
                {
                    Console.WriteLine("!!!Entered meat category doesnt exist!!!");
                }
            } while (true);

            return new Meat(product, type, category);
        }

        private Product CreateProductDialog()
        {
            string tempName;
            double tempPrice;
            double tempWeight;

            Console.Write("Enter name: ");
            tempName = Console.ReadLine();

            do
            {
                Console.Write("Enter price: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out tempPrice))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("!!!Price wasnt entered correctly!!!");
                }
            } while (true);

            do
            {
                Console.Write("Enter weight: ");
                string temp = Console.ReadLine();
                if (double.TryParse(temp, out tempWeight))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("!!!Weight wasnt entered correctly!!!");
                }
            } while (true);

            return new Product(tempName, tempPrice, tempWeight);
        }


        public void PrintAllProducts(Storage storage)
        {
            foreach (var item in storage)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
