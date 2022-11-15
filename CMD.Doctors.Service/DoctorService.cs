using AutoMapper;
using CMD.Doctors.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CMD.Doctors.Service
{    
    public class DoctorService : IDoctorService
    {
        BusinessLogic.DoctorManager manager = BusinessLogic.DoctorManager.GetDoctorManagerinstance();

        public bool AddDoctor(Doctor doctor)
        {
            bool isAdded = false;   
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            DoctorDTO doctorDTO = mapper.Map<DoctorDTO>(doctor);
           
                isAdded = manager.AddDoctor(doctorDTO);
            
           
            return isAdded;
        }

        public List<Doctor> GetAllDoctors()
        {
            List<DoctorDTO> doctors= manager.GetAllDoctors();
            
          
            List<Doctor> allDoctors = new List<Doctor>();
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>());
            var mapper = new Mapper(config);

            for (int i = 0; i < doctors.Count; i++)
            {
                Doctor doctor = mapper.Map<Doctor>(doctors[i]);
                allDoctors.Add(doctor);
            }
            return allDoctors;
        }

        public Doctor GetDoctorByNpiNo(string npiNo)
        {
            DoctorDTO doc = manager.GetDoctorByNpiNo(npiNo);
           
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>());
            var mapper = new Mapper(config);
            Doctor doctor = mapper.Map<Doctor>(doc);

            return doctor;
        }

        public Doctor GetDoctorByEmailid(String EmailId) 
        {
            DoctorDTO doc = manager.GetDoctorByEmailid(EmailId);
           
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>());
            var mapper = new Mapper(config);
            Doctor doctor = mapper.Map<Doctor>(doc);

            return doctor;
        }

        public List<Doctor> GetDoctorsByNpiNos(List<String> npiNos)
        {
            List<Doctor> docs= new List<Doctor>();
            
                foreach(var no in npiNos)
                {
                    DoctorDTO doc = manager.GetDoctorByNpiNo(no);

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>());
                    var mapper = new Mapper(config);
                    Doctor doctor = mapper.Map<Doctor>(doc);
                    docs.Add(doctor); 
                }
            
           
            return docs;
        }
        public bool RemoveDoctor(string npiNo)
        {
            bool IsRemoved = manager.DeleteDoctor(npiNo);
           
            return IsRemoved;
        }

        public bool SignOut()
        {
            manager = null;
            return true;
        }

        public bool UpdateDoctor(Doctor doctor, string npiNo)
        {
            bool IsUpadated = false;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            DoctorDTO doctorDTO = mapper.Map<DoctorDTO>(doctor);
            
                IsUpadated = manager.UpdateDoctor(doctorDTO, npiNo);
           
            return IsUpadated;
        }

        public bool ValidateDoctor(string emailId, string password)
        {
            bool IsValid = manager.ValidateDoctorForSignIn(emailId, password);
            
           
            return IsValid;
        }
    }
}
