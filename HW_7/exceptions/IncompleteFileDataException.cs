using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7.exceptions
{
    class IncompleteFileDataException: Exception
    {
        public IncompleteFileDataException()
        {
        }

        public IncompleteFileDataException(string message) : base(message)
        {
        }
    }
}
