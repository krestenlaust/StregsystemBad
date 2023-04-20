using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregsystem.Core.Exceptions
{
    [Serializable]
    public class InvalidTimestampValueDataProviderException : Exception
    {
        public InvalidTimestampValueDataProviderException() { }
        public InvalidTimestampValueDataProviderException(string message) : base(message) { }
        public InvalidTimestampValueDataProviderException(string message, Exception inner) : base(message, inner) { }
        protected InvalidTimestampValueDataProviderException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
