using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.exceptions
{
    class IncorrectPriceFileException : Exception
    {
        public IncorrectPriceFileException()
        {
        }

        public IncorrectPriceFileException(string message) : base(message)
        {
        }
    }
}
