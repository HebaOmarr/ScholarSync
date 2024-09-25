using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScholarSyncMVC.Models;

namespace ScholarSyncMVC.Data
{
    public class ScholarSyncConext:IdentityDbContext<AppUser>
    {
        public ScholarSyncConext(DbContextOptions<ScholarSyncConext> options):base(options) 
        {
             
        }

        public DbSet<University> Universities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Requirements> Requirements { get; set; }
        public DbSet<Scholarship> Scholarships { get; set; }


    }
}
