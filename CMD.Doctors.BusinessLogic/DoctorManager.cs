using AutoMapper;
using CMD.Doctors.DTOs;
using CMD.Doctors.Models;
using CMD.Doctors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Doctors.BusinessLogic
{
    public class DoctorManager
    {
        private DoctorManager() { }
        private static DoctorManager Instance = null;
        public static DoctorManager GetDoctorManagerinstance()
        {
            if (Instance == null)
            {
                Instance = new DoctorManager();
            }
            return Instance;
        }
        DbManager dbManager = DbManager.GetDbManagerInstance();
        public bool AddDoctor(DoctorDTO doctorDTO)
        {
            bool isAdded = false;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>());
            var mapper = new Mapper(config);
            Doctor doctor = mapper.Map<Doctor>(doctorDTO);
            try
            {
                isAdded = dbManager.AddDoctor(doctor);
            }
            catch (Exception) { throw; }

            return isAdded;
        }

        public bool DeleteDoctor(String npiNo)
        {
            bool isDeleted = false;
            long idToBeSearched = GetDoctorIdUsingNpiNo(npiNo);
            try
            {
                isDeleted = dbManager.DeleteDoctorById(idToBeSearched);
            }
            catch (Exception) { throw; }
            return isDeleted;
        }

        public List<DoctorDTO> GetAllDoctors()
        {
            List<Doctor> doctors;
            try
            {
                doctors = dbManager.GetAllDoctors();
            }
            catch(Exception) { throw; }   
            List<DoctorDTO> allDoctors = new List<DoctorDTO>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            for (int i = 0; i < doctors.Count(); i++)
            {
                DoctorDTO doctor = mapper.Map<DoctorDTO>(doctors[i]);
                allDoctors.Add(doctor);
            }
            return allDoctors;
        }

        public DoctorDTO GetDoctorByNpiNo(string npiNo)
        {
            Doctor doc;
            try
            {
                doc = dbManager.GetDoctorById(npiNo);
            }
            catch (Exception) { throw; }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            DoctorDTO doctor = mapper.Map<DoctorDTO>(doc);

            return doctor;
        }
        public DoctorDTO GetDoctorByEmailid(string Email)
        {
            Doctor doc;
            try
            {
                doc = dbManager.GetDoctorByEmailId(Email);
            }
            catch (Exception) { throw; }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>());
            var mapper = new Mapper(config);
            DoctorDTO doctor = mapper.Map<DoctorDTO>(doc);

            return doctor;
        }

        public bool UpdateDoctor(DoctorDTO doctorDTO, String npiNo)
        {
            bool isUpdated = false;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>());
            var mapper = new Mapper(config);
            Doctor doctor = mapper.Map<Doctor>(doctorDTO);
            try
            {
                isUpdated = dbManager.UpdateDoctor(doctor, npiNo);
            }
            catch(Exception) { throw; }
            return isUpdated;
        }

        public bool ValidateDoctorForSignIn(string emailId, string password)
        {
            bool isValid = false;
            try
            {
                isValid = dbManager.ValidateDoctorForSignIn(emailId, password);
            }
            catch (Exception) { throw; }
            return isValid;
        }

        private long GetDoctorIdUsingNpiNo(string npiNo)
        {
            long idToBeSearched = -1;
            List<DoctorDTO> docList;
            try
            {
                docList = GetAllDoctors();

                foreach (DoctorDTO doctorDTO in docList)
                {
                    if (doctorDTO.NpiNo.Equals(npiNo))
                    {
                        idToBeSearched = doctorDTO.Id;
                        break;
                    }
                }
                if (idToBeSearched == -1) throw new WrongNpiIdException("You Have Entered Wrong NPI ID !!!");
            }
            catch (WrongNpiIdException) { throw; }
            catch (Exception) { throw; }
            return idToBeSearched;
        }
    }

    }
