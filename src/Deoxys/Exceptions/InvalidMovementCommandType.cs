using System;
using System.Runtime.Serialization;

namespace Deoxys.Exceptions
{
    [Serializable]
    public class InvalidMovementCommandType : Exception
    {
        public InvalidMovementCommandType()
            : this("imvalid movement command")
        {

        }
        public InvalidMovementCommandType(string message)
        : base(message)
        {

        }
        public InvalidMovementCommandType(string message, Exception inner)
        : base(message, inner)
        {

        }
        protected InvalidMovementCommandType(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}