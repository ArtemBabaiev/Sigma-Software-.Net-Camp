using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6.Task1.entity
{
    class Quarter
    {
        public static string GetQuarterMonths(int quarterNumber) 
        {
            if (quarterNumber<=0 || quarterNumber>4)
            {
                throw new Exception("Incorect quarter number");
            }
            string result = "";
            for (int i = 2; i >=0 ; i--)
            {
                DateTime date = new DateTime(2022, 3*quarterNumber - i, 1);

                result += date.ToString("MMMM").ToUpper() + " ";
            }
            return result;
        }
    }
}
