using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Task1.exceptions
{
    class InvalidInputException : Exception
    {
        public InvalidInputException()
        {
        }

        public InvalidInputException(string message) : base(message)
        {
        }

        public InvalidInputException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
