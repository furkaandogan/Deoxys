using System;
using System.Runtime.Serialization;

namespace Deoxys.Exceptions
{
    [Serializable]
    public class RoverDropException : Exception
    {
        public RoverDropException()
            : this("rover is failed dropped")
        {

        }
        
        public RoverDropException(string message)
        : base(message)
        {

        }
        public RoverDropException(string message, Exception inner)
        : base(message, inner)
        {

        }
        protected RoverDropException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}