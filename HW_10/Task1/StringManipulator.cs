using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_10.Task1
{
    class StringManipulator
    {
        public static string[] SplitTextBy(string text, string separator = @" ")
        {
            return Regex.Split(text, separator);
        }
        public static string CleanTextFromExtraSpaces(string text)
        {
            return Regex.Replace(text, @"\s+", " ");
        }
        public static string[] TransformAllToLower(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
            }
            return words;
        }

        public static bool IsAllUpper(string str)
        {
            foreach (char item in str)
            {
                if (char.IsLower(item))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsAllLower(string str)
        {
            foreach (char item in str)
            {
                if (char.IsUpper(item))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsFirstUpper(string str)
        {
            return char.IsUpper(str[0]);
        }

    }
}
