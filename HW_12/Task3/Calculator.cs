using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_12.Task3
{
    static class Calculator
    {

        public static double Evaluate(string expression)
        {
            string[] elements = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //LIFO
            Stack<double> numbers = new();
            try
            {
                foreach (var item in elements)
                {
                    //якщо число
                    if (Regex.IsMatch(item, @"^-?\d*\.?\d+$"))
                    {
                        numbers.Push(double.Parse(item));
                    }
                    //якщо операція
                    else if (Regex.IsMatch(item, @"\+|\-|\/|\*|\^"))
                    {
                        double first = numbers.Pop();
                        double second = numbers.Pop();
                        switch (item)
                        {
                            case "+":
                                numbers.Push(second + first);
                                break;
                            case "-":
                                numbers.Push(second - first);
                                break;
                            case "*":
                                numbers.Push(second * first);
                                break;
                            case "/":
                                numbers.Push(second / first);
                                break;
                            case "^":
                                numbers.Push(Math.Pow(second, first));
                                break;
                        }
                    }
                    //якщо функція
                    else
                    {
                        double variable = numbers.Pop();
                        switch (item.ToLower())
                        {
                            case "sin":
                                numbers.Push(Math.Sin(variable));
                                break;
                            case "cos":
                                numbers.Push(Math.Cos(variable));
                                break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("not correct format of string");
            }
            
            return numbers.Pop();
        }
    }
}
