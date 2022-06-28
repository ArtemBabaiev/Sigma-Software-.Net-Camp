using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Task1.exceptions
{
    class InvalidProductDataException : Exception
    {
        public InvalidProductDataException()
        {
        }

        public InvalidProductDataException(string message) : base(message)
        {
        }

        public InvalidProductDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidProductDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
