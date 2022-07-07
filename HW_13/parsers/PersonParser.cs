using HW_13.entities;
using HW_13.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_13.parsers
{
    internal static class PersonParser
    {
        public static Person Parse(string text)
        {

            string[] atributes = text.Split("|");

            string[] posStr = Regex.Replace(atributes[4], @"\(|\)", "").Split(";");
            Position pos = new Position(double.Parse(posStr[0]), double.Parse(posStr[0]));
            Status status = (Status)Enum.Parse(typeof(Status), atributes[3].ToUpper());


            return new Person(atributes[0], int.Parse(atributes[1]), int.Parse(atributes[2]), pos, status);



        }
    }
}
