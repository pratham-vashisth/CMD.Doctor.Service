using System;
using System.Runtime.Serialization;

namespace CMD.Doctors.BusinessLogic
{
    [Serializable]
    internal class WrongNpiIdException : Exception
    {
        public WrongNpiIdException()
        {
        }

        public WrongNpiIdException(string message) : base(message)
        {
        }

        public WrongNpiIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongNpiIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}