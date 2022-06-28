using HW_12.Task1.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_12.Task1.validators
{
    static class Validation
    {
        public static bool IsDate(string date)
        {
            return DateTime.TryParse(date, out DateTime temp);
        }
        public static bool IsNumber(string number)
        {
            return Regex.IsMatch(number, @"^-?\d*\.?\d+$");
        }

        public static bool IsStringEnumOf(string name, Type type)
        {
            return Enum.GetNames(type).Contains(name.ToUpper());
        }

        public static bool IsValidLine(string line)
        {
            string typePattern = String.Join('|', Enum.GetNames(typeof(ProductType)));
            string namePattern = @"[A-Za-zА-Яа-яІіЇї\d]+";
            string priceAndWeightPattern = @"( \d+.\d*){2}";
            string othersPattern = @"( .+)*";
            return Regex.IsMatch(line, @$"{typePattern} {namePattern}{priceAndWeightPattern}{othersPattern}", RegexOptions.IgnoreCase);
        }
    }
}
