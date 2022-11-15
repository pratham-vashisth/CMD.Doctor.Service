using System;
using System.Runtime.Serialization;

namespace CMD.Doctors.Repository
{
    [Serializable]
    internal class NoDoctorsAtAllException : Exception
    {
        public NoDoctorsAtAllException()
        {
        }

        public NoDoctorsAtAllException(string message) : base(message)
        {
        }

        public NoDoctorsAtAllException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoDoctorsAtAllException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}