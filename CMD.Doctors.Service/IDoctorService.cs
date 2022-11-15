using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CMD.Doctors.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IDoctorService
    {

        
        [OperationContract]
       // [FaultContract(typeof(ServiceFault))]
        bool ValidateDoctor(String emailId, String password);
    
        [OperationContract]
       // [FaultContract(typeof(ServiceFault))]
        bool AddDoctor(Doctor doctor); //at time of sign up

        [OperationContract]
        //[FaultContract(typeof(ServiceFault))]
        List<Doctor> GetAllDoctors();

        [OperationContract]
        //[FaultContract(typeof(ServiceFault))]
        Doctor GetDoctorByNpiNo(String npiNo);


        [OperationContract]
        //[FaultContract(typeof(ServiceFault))]
        Doctor GetDoctorByEmailid(String Emailid);

        [OperationContract]
        //[FaultContract(typeof(ServiceFault))]
        List<Doctor> GetDoctorsByNpiNos(List<String> npiNos);

        [OperationContract]
        //[FaultContract(typeof(ServiceFault))]
        bool UpdateDoctor(Doctor doctor, String npiNo);

        [OperationContract]
        //[FaultContract(typeof(ServiceFault))]
        bool RemoveDoctor(String npiNo);

        [OperationContract]
        //[FaultContract(typeof(ServiceFault))]
        bool SignOut();
    }
}
