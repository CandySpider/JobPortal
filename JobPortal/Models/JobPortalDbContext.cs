using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace JobPortal.Models
{
    public class JobPortalDbContext : DbContext
    {
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options) : base(options) { }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }    
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<SkillSet> SkillSets { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillSet>()
                .HasMany(e => e.Skills)
                .WithMany(e => e.SkillSets);
                 
        }
    }
}
