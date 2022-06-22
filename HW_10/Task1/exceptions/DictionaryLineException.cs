using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Task1.exceptions
{
    class DictionaryLineException : Exception
    {
        public DictionaryLineException()
        {
        }

        public DictionaryLineException(string message) : base(message)
        {
        }

        public DictionaryLineException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DictionaryLineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
