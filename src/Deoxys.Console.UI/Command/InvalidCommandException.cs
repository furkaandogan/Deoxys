using System;
using System.Runtime.Serialization;

namespace Deoxys.Console.UI.Command
{
    [Serializable]
    public class InvalidCommandException 
        : Exception
    {
        public InvalidCommandException()
            : this("imvalid command")
        {

        }
        public InvalidCommandException(string message)
        : base(message)
        {

        }
        public InvalidCommandException(string message, Exception inner)
        : base(message, inner)
        {

        }
        protected InvalidCommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}