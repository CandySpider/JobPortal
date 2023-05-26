using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Models
{
    public class JobPortalDbContext : IdentityDbContext
    {
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options) : base(options) { }
        public DbSet<Application> Applications { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<Candidate> Candidates { get; set; } = null!;
        public DbSet<SkillSet> SkillSets { get; set; } = null!;
        public DbSet<Skill> Skills { get; set; } = null!;
        public DbSet<Employer> Employers { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SkillSet>()
                .HasMany(e => e.Skills)
                .WithMany(e => e.SkillSets);
            
        }
    }
}
