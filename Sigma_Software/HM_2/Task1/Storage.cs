using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sigma_Software.HM_2.Task1
{
    internal class Storage
    {
        List<object> allProducts;

        public List<object> AllProducts 
        { 
            get => allProducts; 
            protected set
            {
                foreach (var item in value)
                {
                    if (item is not Product)
                    {
                        throw new ArgumentException();
                    }
                }
                allProducts = value;
            } 
        }

        public Storage(List<object> allProducts)
        {
            this.AllProducts = allProducts;
        }

        public Storage()
        {
            this.AllProducts = new List<object>();
        }

        public void FillStorage()
        {
            do
            {
                Console.WriteLine("Choose product type:\n1 - Product\n2 - Meat\n3 - Diary product");
                Console.Write("Input (1/2/3): ");
                switch (Console.ReadLine())
                {
                    case "1":
                        AllProducts.Add(CreateProduct());
                        break;
                    case "2":
                        AllProducts.Add(CreateMeat());
                        break;
                    case "3":
                        AllProducts.Add(CreateDiaryProduct());
                        break;
                    default:
                        Console.WriteLine("!!!Invalid input!!!");
                        continue;

                }
            } while (!IsFillEnded());
        }
        private bool IsFillEnded()
        {
            while (true)
            {
                Console.Write("Do you want to exit?\nAnswer(Y/y, N/n): ");
                switch (Console.ReadLine())
                {
                    case "Y":
                        return true;
                    case "y":
                        return true;
                    case "N":
                        return false;
                    case "n":
                        return false;
                    default:
                        break;
                }
            }

        }

        private Product CreateProduct()
        {
            string name;
            double weight;
            double price;

            Console.Write("Input name: ");
            name = Console.ReadLine();

            while (true)
            {
                Console.Write("Input price: ");
                if (Double.TryParse(Console.ReadLine(), out price))
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Input weight: ");
                if (Double.TryParse(Console.ReadLine(), out weight))
                {
                    break;
                }
            }

            return new Product(name, price, weight);
        }

        private Product CreateDiaryProduct()
        {
            Product product = CreateProduct();
            DateTime dt;

            while (true)
            {
                Console.Write("Input expire date (yyyy mm dd): ");
                string input = Console.ReadLine();
                Regex regex = new Regex(@"^\d\d\d\d \d\d \d\d");
                if (!regex.IsMatch(input))
                {
                    Console.WriteLine("!!!Invalid input!!!");
                    continue;
                }
                string[] dateStr = input.Split(" ");
                int[] dateInt = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    dateInt[i] = Convert.ToInt32(dateStr[i]);
                }
                try
                {
                    dt = new DateTime(dateInt[0], dateInt[1], dateInt[2]);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("!!!Invalid date!!!");
                    continue;
                }
                
            }
            return new DiaryProducts(product, dt);
        }

        private Product CreateMeat()
        {
            Product product = CreateProduct();
            MeatCategory mc;
            MeatType mt;
            while (true)
            {
                Console.WriteLine("Choose meat category:\n1 - High\n2 - First\n3 - Second");
                Console.Write("Input (1/2/3): ");
                switch (Console.ReadLine())
                {
                    case "1":
                        mc = MeatCategory.HIGH;
                        break;
                    case "2":
                        mc = MeatCategory.FIRST;
                        break;
                    case "3":
                        mc = MeatCategory.SECOND;
                        break;
                    default:
                        Console.WriteLine("!!!Invalid input!!!");
                        continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine("Choose meat type:\n1 - CHICKEN\n2 - MUTTON\n3 - PORK\n4 - VEAL");
                Console.Write("Input (1/2/3/4): ");
                switch (Console.ReadLine())
                {
                    case "1":
                        mt = MeatType.CHICKEN;
                        break;
                    case "2":
                        mt = MeatType.MUTTON;

                        break;
                    case "3":
                        mt = MeatType.PORK;
                        break;
                    case "4":
                        mt = MeatType.VEAL;
                        break;
                    default:
                        Console.WriteLine("!!!Invalid input!!!");
                        continue;
                }
                break;
            }
            return new Meat(product, mt, mc);
        }

        public void PrintAllProducts()
        {
            foreach (var item in AllProducts)
            {
                Console.WriteLine(item);
            }
        }

        public List<Meat> GetAllMearProducts()
        {
            List<Meat> result = new List<Meat>();
            foreach (var item in AllProducts)
            {
                if (item is Meat)
                {
                    result.Add((Meat)item);
                }
            }
            return result;
        }
        
        public void ChangeAllPricesByPercentage(double percentage)
        {
            foreach (var item in AllProducts)
            {
                switch (item)
                {
                    case Meat m:
                        m.ChangePrice(percentage);
                        break;
                    case DiaryProducts d:
                        d.ChangePrice(percentage);
                        break;
                    case Product p:
                        p.ChangePrice(percentage);
                        break;
                    default:
                        break;
                }
            }
        }
    
        public object this[int i]
        {
            get 
            {
                if (i >= 0 && i < allProducts.Count)
                {
                    return AllProducts[i];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set 
            {
                if (i >= 0 && i < allProducts.Count)
                {
                    if (value is Product)
                    {
                        AllProducts[i] = value;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();

                }

            }
        }
    }

}
