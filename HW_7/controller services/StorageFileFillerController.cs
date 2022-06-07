using HW_7.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7.controller_services
{
    class StorageFileFillerController
    {
        public Storage FillStorage(string path)
        {
            StorageFileFillerService fileFiller = new StorageFileFillerService();
            Storage storage = null;
            try
            {
                storage = fileFiller.LoadStorage(path);
            }
            catch (DirectoryNotFoundException)
            {
                string pathNew;
                int repit = 0;
                do
                {
                    Console.Write("Directory doesnt exist. Try again. New Path: ");
                    pathNew = Console.ReadLine();
                    int lastIndex = path.LastIndexOf('/') == -1 ? path.LastIndexOf('/') : path.LastIndexOf('\\');
                    if (Directory.Exists(pathNew[..lastIndex]))
                    {
                        storage = fileFiller.LoadStorage(path);
                        break;
                    }
                    repit++;
                } while (repit <= 2);
                Console.WriteLine("Out of tries");
            }
            catch (FileNotFoundException)
            {
                string pathNew;
                int repit = 0;
                do
                {
                    Console.Write("File doesnt exist in directory. Try again. New Path: ");
                    pathNew = Console.ReadLine();
                    if (File.Exists(pathNew))
                    {
                        storage = fileFiller.LoadStorage(path);
                        break;
                    }
                } while (repit <= 2);
                Console.WriteLine("Out of tries");
            }

            return storage;
        }
    }
}
