using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Doctors.Repository
{
    public class DoctorsDbContext : DbContext
    {
        public DoctorsDbContext() : base("name=CMDConnectionString") { }

        public DbSet<Models.Doctor> doctors { get; set; }
        public DbSet<Models.SignInDoctor> doctorsSignIn { get; set; }

    }
}
