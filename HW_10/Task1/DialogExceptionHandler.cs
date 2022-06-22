using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Task1
{
    class DialogExceptionHandler
    {
        static int numberOfProblems = 0;
        public static bool IncorrectLineHandler()
        {
            if (IsAcceptable())
            {
                Console.WriteLine("Please correct data in Dictionary.txt\nPress Enter when you are done");
                Console.ReadLine();
                numberOfProblems++;
                return true;
            }
            else
            {
                NoMoreTriesHandler();
                
                return false;
            }
        }

        public static bool WordDublicationHandler()
        {
            if (IsAcceptable())
            {
                Console.WriteLine("Please delete dublicated words from Dictionary.txt\nPress Enter when you are done");
                Console.ReadLine();
                numberOfProblems++;
                return true;
            }
            else
            {
                NoMoreTriesHandler();
                return false;

            }

        }

        public static bool NoTranslationHandler(exceptions.NoTranslationInDictionaryException e)
        {
            if (IsAcceptable())
            {
                Console.WriteLine($"Please add word \"{e.Message}\" with translation \nPress Enter when you are done");
                Console.ReadLine();
                numberOfProblems++;
                return true;
            }
            else
            {
                NoMoreTriesHandler();
                return false;
            }

        }

        private static void NoMoreTriesHandler()
        {
            Console.WriteLine("Out of tries to correct dictionary");
        }

        private static bool IsAcceptable()
        {
            if (numberOfProblems < 3)
            {
                return true;
            }
            return false;
        }
    }
}
