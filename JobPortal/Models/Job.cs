using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [Required]
        public int EmployerId { get; set; }
        [Required]
        public int SkillSetId { get; set; }

        [Required]
        public string JobTitle { get; set; } = string.Empty;

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public string? JobDescription { get; set; }

       

        [Required]
        public string? Location { get; set; }

        [Required]
        public int? Salary { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }
        [Required]
        public DateTime ApplicationDeadline { get; set; }

        public string JobType { get; set; } = string.Empty;   //remote, hybrid, on-site

        public SkillSet SkillSet { get; set; } = null!;
        public Employer Employer { get; set; } = null!;
    }
}
