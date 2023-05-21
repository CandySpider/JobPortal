using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        [Required]
        public string CandidateName { get; set; } = string.Empty;
        [Required]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? ProfilePhotoUrl { get; set; }
        public string? ResumeFileUrl { get; set; }

        public ICollection<Application> Applications { get; } =new List<Application>();
        
    }
}
