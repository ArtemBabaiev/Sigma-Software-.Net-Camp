using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.exceptions
{
    class IncompleteDishDataException : Exception
    {
        public IncompleteDishDataException()
        {
        }

        public IncompleteDishDataException(string message) : base(message)
        {
        }
    }
}
