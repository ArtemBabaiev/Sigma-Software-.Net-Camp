using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Task1.exceptions
{
    class DictionaryWordDublicateException : Exception
    {
        public DictionaryWordDublicateException()
        {
        }

        public DictionaryWordDublicateException(string message) : base(message)
        {
        }

        public DictionaryWordDublicateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DictionaryWordDublicateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
