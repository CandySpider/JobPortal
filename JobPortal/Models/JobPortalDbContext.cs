using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Models
{
    public class JobPortalDbContext : IdentityDbContext<ApplicationUser>
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
            modelBuilder.Entity<ApplicationUser>().HasKey(l => l.Id);
            modelBuilder.Entity<Candidate>()
            .HasOne(p => p.ApplicationUser)
            .WithOne(u => u.Candidate)
            .HasForeignKey<Candidate>(p => p.ApplicationUserId);
            modelBuilder.Entity<Employer>()
                .HasOne(p => p.ApplicationUser)
                .WithOne(u => u.Employer)
                .HasForeignKey<Employer>(p => p.ApplicationUserId);

        }
    }
}
