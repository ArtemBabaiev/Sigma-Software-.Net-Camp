using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Task1.exceptions
{
    class InvalidStorageLineException : Exception
    {
        public InvalidStorageLineException()
        {
        }

        public InvalidStorageLineException(string message) : base(message)
        {
        }

        public InvalidStorageLineException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidStorageLineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
