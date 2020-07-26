using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewRepoAPIWEBERestFinalProject.Models
{
    public class NewRepoAPIWEBRestFinalProjectContext : IdentityDbContext
    {
        public NewRepoAPIWEBRestFinalProjectContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Services> Services { get; set; }
        
        public DbSet<Orders> Orders { get; set; }

    }
}
