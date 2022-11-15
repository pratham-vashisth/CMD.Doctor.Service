using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Doctors.Service
{
    [DataContract]
    public class ServiceFault
    {
        private string errorMessage;
        public ServiceFault(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }
        [DataMember]
        public String Message 
        {
            get { return this.errorMessage; }
            set { this.errorMessage = value; }
        }

        //this is a try to access property using . operator
    }
}

