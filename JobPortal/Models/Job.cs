using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        public string JobTitle { get; set; } = string.Empty;

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public string? JobDescription { get; set; }

        [Required]
        public string? Requirements { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public decimal? Salary { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }
        [Required]
        public DateTime ApplicationDeadline { get; set; }

        // Additional job listing information can be added as properties here
        public string JobType { get; set; } = string.Empty;   //remote, hybrid, on-site
        public DateTime PostedDate { get; set; }
    }
}
