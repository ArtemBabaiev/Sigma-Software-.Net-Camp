using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Task1.exceptions
{
    class NoTranslationInDictionaryException : Exception
    {
        public NoTranslationInDictionaryException()
        {
        }

        public NoTranslationInDictionaryException(string message) : base(message)
        {
        }

        public NoTranslationInDictionaryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoTranslationInDictionaryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
