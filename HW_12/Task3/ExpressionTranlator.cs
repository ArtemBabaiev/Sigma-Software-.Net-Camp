using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_12.Task3
{
    static class ExpressionTranlator
    {
        //працює за умови що всі елементи розділені пробілом
        //наприклад 2 / sin ( 1 - 5 ) ^ 2"
        public static string PolishFormOf(string expression)
        {

            StringBuilder result = new("");
            Stack<string> ops = new();
            var elements = expression.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                foreach (var item in elements)
                {
                    if (Regex.IsMatch(item, @"^-?\d*\.?\d+$"))
                    {
                        result.Append(item + " ");
                    }
                    else if (item == "sin" || item == "cos")
                    {
                        ops.Push(item);
                    }
                    else if (item == "(")
                    {
                        ops.Push(item);
                    }
                    else if (item == ")")
                    {
                        while (true)
                        {
                            string operation = ops.Peek();
                            //виконуємо поки не зустрінемо відкриваючу дужку у стеці
                            if (operation == "(")
                            {
                                ops.Pop();
                                //перевірка на те що дужки належать функції
                                if (ops.Peek() == "sin" || ops.Peek() == "cos")
                                {
                                    result.Append(ops.Pop() + " ");
                                }
                                break;
                            }
                            result.Append(ops.Pop() + " ");
                        }

                    }
                    else if (Regex.IsMatch(item, @"\+|\-|\/|\*|\^"))
                    {
                        if (ops.Count != 0)
                        {
                            while (ops.Peek() == "sin" || ops.Peek() == "cos"
                                || GetPrior(ops.Peek()) >= GetPrior(item)
                                )
                            {
                                result.Append(ops.Pop() + " ");
                            }

                        }
                        ops.Push(item);
                    }

                }
                while (ops.Count != 0)
                {
                    result.Append(ops.Pop() + " ");
                }
            }
            catch (Exception)
            {
                throw new Exception("Expression is not correct format");
            }


            return result.ToString().Trim();
        }
        private static int GetPrior(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;

                case "*":
                case "/":
                    return 2;

                case "^":
                    return 3;
            }
            return -1;
        }
    }
}
