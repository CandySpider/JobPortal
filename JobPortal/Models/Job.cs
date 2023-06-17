using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Job
    {
        [Key]
        [BindNever]
        public int JobId { get; set; }
        [BindNever]
        public int EmployerId { get; set; }
        [BindNever]
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

        public int? Salary { get; set; }

        [BindNever]
        public DateTime? CreatedDate { get; set; }
        [Required]
        public DateTime ApplicationDeadline { get; set; }

        public string JobType { get; set; } = string.Empty;   //remote, hybrid, on-site

        [BindNever]
        public SkillSet? SkillSet { get; set; }
        [BindNever]
        public Employer? Employer { get; set; }

        [BindNever]
        public List<Application> Applications { get;} = new List<Application>();
    }
}
