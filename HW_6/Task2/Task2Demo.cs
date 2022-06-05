using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6.Task2
{
    class Task2Demo
    {
        public static void Start()
        {
            TextFileManipulator manipulator = new TextFileManipulator(@"Task2/txtFiles/text.txt");

            manipulator.WriteToFile(manipulator.SplitTextBySentence(), "Result.txt");

            foreach (var item in manipulator.GetMinMaxOfSentences(manipulator.SplitTextBySentence()))
            {
                Console.WriteLine("MIN: " + item.Item1 + " , MAX: " + item.Item2);
            }
        }
    }
}
