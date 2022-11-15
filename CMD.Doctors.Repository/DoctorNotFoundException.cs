using System;
using System.Runtime.Serialization;

namespace CMD.Doctors.Repository
{
    [Serializable]
    internal class DoctorNotFoundException : Exception
    {
        public DoctorNotFoundException()
        {
        }

        public DoctorNotFoundException(string message) : base(message)
        {
        }

        public DoctorNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DoctorNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}