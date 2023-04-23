using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }

        [Required]
        public int JobId { get; set; }

        [Required] public string ApplicantName { get; set; } = string.Empty;

        [Required] public string ApplicantEmail { get; set; } = string.Empty;

        [Required] public string ResumeFileName { get; set; } = string.Empty;

        [Required]
        public DateTime ApplicationDate { get; set; }

        // Additional application information can be added as properties here
    }

}
