using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Resume
    {
        [Key]
        public int ResumeId { get; set; }

        [Required] public string ApplicantName { get; set; } = string.Empty;

        [Required] public string ResumeFileName { get; set; } = string.Empty;

        
    }
}
