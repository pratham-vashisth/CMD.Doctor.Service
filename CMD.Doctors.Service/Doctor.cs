using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Doctors.Service
{
    [DataContract]
    public class Doctor
    {
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String EmailId { get; set; }
        [DataMember]
        public String PhoneNo { get; set; }
        [DataMember]
        public String PracticeLocation { get; set; }      
        [DataMember]
        public String Speciality { get; set; }       
        [DataMember]
        public String NpiNo { get; set; }       
        [DataMember]
        public String Password { get; set; }
        [DataMember]
        public String Gender { get; set; }
        [DataMember]
        public String Image { get; set; }
    }
}
