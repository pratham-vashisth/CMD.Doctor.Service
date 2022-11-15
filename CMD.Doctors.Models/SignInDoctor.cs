using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Doctors.Models
{
    public class SignInDoctor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String emailId { get; set; }
        [Required]
        public String password { get; set; }
    }
}
