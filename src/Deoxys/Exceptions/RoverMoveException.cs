using System;
using System.Runtime.Serialization;

namespace Deoxys.Exceptions
{
    [Serializable]
    public class RoverMoveException : Exception
    {
        public RoverMoveException() { }
        public RoverMoveException(string message)
        : base(message)
        {

        }
        public RoverMoveException(string message, Exception inner)
        : base(message, inner)
        {

        }
        protected RoverMoveException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}