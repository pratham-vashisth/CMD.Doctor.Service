using CMD.Doctors.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Doctors.Repository
{
    public class DbManager
    {
        private DbManager() { }
        private static DbManager instance = null;
        public static DbManager GetDbManagerInstance()
        {
            if (instance == null)
            {
                instance = new DbManager();
            }
            return instance;
        }
        DoctorsDbContext dbContext = new DoctorsDbContext();
        public bool AddDoctor(Doctor doctor)
        {
            bool isAdded = false;

            try
            {
                SignInDoctor docSignIn = new SignInDoctor();
                docSignIn.emailId = doctor.EmailId;
                docSignIn.password = doctor.Password;

                dbContext.doctorsSignIn.Add(docSignIn);
                dbContext.doctors.Add(doctor);
                dbContext.SaveChanges();
                isAdded = true;
            }
            catch (DbEntityValidationException) { throw; }
            catch (Exception) { throw; }
            return isAdded;
        }

        public bool DeleteDoctorById(long id)
        {
            bool isDeleted = false;
            var doctorToBeDeleted = dbContext.doctors.FirstOrDefault(x => x.Id == id);
            try
            {
                if (doctorToBeDeleted != null)
                {
                    dbContext.doctors.Remove(doctorToBeDeleted);
                    dbContext.SaveChanges();
                    isDeleted = true;
                }

                else
                {
                    throw new DoctorNotFoundException("Doctor not Found with Such Requirements !!!");
                }
            }
            catch (DoctorNotFoundException ex) { throw; }
            catch (Exception) { throw; }
            return isDeleted;
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> allPatients;
            try
            {
                allPatients = dbContext.doctors.ToList();
                if (allPatients.Count < 1)
                {
                    throw new NoDoctorsAtAllException("There are no Doctors Present at this Moment !!!");
                }
            }
            catch (NoDoctorsAtAllException) { throw; }
            catch (Exception) { throw; }
            return allPatients;
        }

        public Doctor GetDoctorById(String id)
        {
            var doctor = dbContext.doctors.FirstOrDefault(x => x.NpiNo.Equals(id));
            try
            {
                if (doctor == null)
                {
                    throw new DoctorNotFoundException("Doctor not Found with Such Requirements !!!");
                }
            }
            catch (DoctorNotFoundException) { throw; }
            catch (Exception) { throw; }
 
            return doctor;
        }

        public Doctor GetDoctorByEmailId(String id)
        {
            var doctor = dbContext.doctors.FirstOrDefault(x => x.EmailId.Equals(id));
            
               
           
            return doctor;
        }

        public bool UpdateDoctor(Doctor doctor, string id)
        {
            bool isUpdated = false;
            var doctorToBeUpdated = dbContext.doctors.FirstOrDefault(x => x.NpiNo.Equals(id));
            try
            {
                if (doctorToBeUpdated != null)
                {
                    doctorToBeUpdated.Name = doctor.Name;
                    doctorToBeUpdated.EmailId = doctor.EmailId;
                    doctorToBeUpdated.PhoneNo = doctor.PhoneNo;
                    doctorToBeUpdated.Speciality = doctor.Speciality;
                    // doctorToBeUpdated.NpiNo = doctor.NpiNo;
                    doctorToBeUpdated.PracticeLocation = doctor.PracticeLocation;

                    dbContext.SaveChanges();
                    isUpdated = true;
                }
                else throw new DoctorNotFoundException("Doctor not Found with Such Requirements !!!");
            }
            catch (DoctorNotFoundException) { throw; }
            catch (Exception) { throw; }
            return isUpdated;
        }

        public bool ValidateDoctorForSignIn(string emailId, string password)
        {
            bool isValid = false;

            var doctorToBeSignedIn = dbContext.doctorsSignIn.FirstOrDefault(x => x.emailId.Equals(emailId));
            
                if (doctorToBeSignedIn != null)
                {
                    if (doctorToBeSignedIn.password.Equals(password))
                    {
                        isValid = true;
                    }

                }
           
            return isValid;
        }
    }
}
