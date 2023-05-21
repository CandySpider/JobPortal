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

        [Required(ErrorMessage = "Please enter the job title.")]
        [StringLength(100)]
        
        public string JobTitle { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please write a description about the job posting.")]
        [StringLength(10000,MinimumLength = 100,ErrorMessage = "The job description should be at least 100 characters long.")]
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
