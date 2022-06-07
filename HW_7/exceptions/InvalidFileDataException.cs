using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7.exceptions
{
    class InvalidFileDataException:Exception
    {
        public InvalidFileDataException()
        {
        }

        public InvalidFileDataException(string message):base(message)
        {
        }
    }
}
