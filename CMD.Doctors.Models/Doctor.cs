using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Doctors.Models
{
    public class Doctor
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String EmailId { get; set; }
        [Required]
        public String PhoneNo { get; set; }
        [Required]
        public String PracticeLocation { get; set; }
        [Required]
        public String Speciality { get; set; }      
        [Required]
        public String NpiNo { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String Gender { get; set; }
        public String Image { get; set; }
    }
}
