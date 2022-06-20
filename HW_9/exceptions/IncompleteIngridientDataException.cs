using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.exceptions
{
    class IncompleteIngridientDataException : Exception
    {
        public IncompleteIngridientDataException()
        {
        }

        public IncompleteIngridientDataException(string message) : base(message)
        {
        }
    }
}
