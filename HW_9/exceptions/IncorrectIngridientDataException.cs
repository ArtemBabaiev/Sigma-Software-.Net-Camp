using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.exceptions
{
    class IncorrectIngridientDataException : Exception
    {
        public IncorrectIngridientDataException()
        {
        }

        public IncorrectIngridientDataException(string message) : base(message)
        {
        }
    }
}
