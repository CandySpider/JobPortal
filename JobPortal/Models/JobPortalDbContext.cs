using Microsoft.EntityFrameworkCore;

namespace JobPortal.Models
{
    public class JobPortalDbContext: DbContext
    {
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options) : base(options) { }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Resume> Resumes { get; set; }
           
    }
}
