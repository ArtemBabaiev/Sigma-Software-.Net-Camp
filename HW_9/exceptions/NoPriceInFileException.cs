using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9.exceptions
{
    class NoPriceInFileException : Exception
    {
        public NoPriceInFileException()
        {
        }

        public NoPriceInFileException(string message) : base(message)
        {
        }
    }
}
