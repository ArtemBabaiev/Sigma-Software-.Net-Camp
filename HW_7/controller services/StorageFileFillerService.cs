using HW_7.entity;
using HW_7.exceptions;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HW_7.controller_services
{
    class StorageFileFillerService
    {
        public Storage LoadStorage(string path)
        {
            Storage storage = new Storage();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    int lineNumber = 1;
                    while (!reader.EndOfStream)
                    {
                        

                        try
                        {
                            string line = reader.ReadLine();
                            string[] data = Regex.Split(line, @"\s+");
                            string prodTypeStr = data[0].ToUpper();
                            ProductTypes prodType;
                            if (Enum.TryParse(prodTypeStr, out prodType))
                            {
                                switch (prodType)
                                {
                                    case ProductTypes.PRODUCT:
                                        storage.AddProduct(CreateProduct(data));
                                        break;
                                    case ProductTypes.MEAT:
                                        storage.AddProduct(CreateMeat(data));
                                        break;
                                    case ProductTypes.DIARY_PRODUCT:
                                        storage.AddProduct(CreateDiaryProduct(data));
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            LogController.WriteExceptionLog($"[ERROR] --{path}-- on line +{lineNumber}+\t" + e.Message);
                        }
                        lineNumber++;
                    }
                }
                return storage;
            }
            catch (Exception e) when (e is DirectoryNotFoundException || e is FileNotFoundException)
            {
                throw e;
            }


        }

        private Product CreateProduct(string[] data)
        {
            string exceptionMessage = "";
            string name;
            double price;
            double weight;
            try
            {
                name = char.ToUpper(data[1][0]) + data[1][1..].ToLower();

                if (!double.TryParse(data[2], out price))
                {
                    exceptionMessage += "invalid price | ";
                }
                if (!double.TryParse(data[3], out weight))
                {
                    exceptionMessage += "invalid weight | ";
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new IncompleteFileDataException("Not enough data to create instance");
            }

            if (exceptionMessage.Length != 0)
            {
                throw new InvalidFileDataException(exceptionMessage);
            }

            return new Product(name, price, weight);


        }

        private Product CreateMeat(string[] data)
        {
            string exceptionMessage = "";

            Product product = null;
            MeatType type;
            MeatCategory category;

            string typeStr;
            string categoryStr;
            try
            {
                product = CreateProduct(data);
            }
            catch (IncompleteFileDataException e)
            {
                throw e;
            }
            catch (InvalidFileDataException e)
            {
                exceptionMessage += e.Message;
            }

            try
            {
                 typeStr = data[4].ToUpper();
                 categoryStr = data[5].ToUpper();
            }
            catch (IndexOutOfRangeException)
            {
                throw new IncompleteFileDataException("Not enough data to create instance");
            }
            

            if (!Enum.TryParse(typeStr, out type))
            {
                exceptionMessage += "invalid meat type | ";
            }
            if (!Enum.TryParse(categoryStr, out category))
            {
                exceptionMessage += "invalid meat category | ";
            }

            if (exceptionMessage.Length != 0)
            {
                throw new InvalidFileDataException(exceptionMessage);
            }


            return new Meat(product, type, category);

        }

        private Product CreateDiaryProduct(string[] data)
        {
            string exceptionMessage = "";

            Product product = null;
            DateTime exprDate;
            string dateStr;

            try
            {
                product = CreateProduct(data);
            }
            catch (IncompleteFileDataException e)
            {
                throw e;
            }

            dateStr = data[4];
            if (!DateTime.TryParse(dateStr, out exprDate))
            {
                exceptionMessage += "invalid date | ";
            }

            if (exceptionMessage.Length != 0)
            {
                throw new InvalidFileDataException(exceptionMessage);
            }


            return new DiaryProduct(product, exprDate);
        }
    }
}
