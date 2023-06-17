using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        [Required]
        public string CandidateName { get; set; } = string.Empty;
        [Required]
        [Phone(ErrorMessage ="Invalid phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? ProfilePhotoUrl { get; set; }
        public string? ResumeFileUrl { get; set; }

        public string? ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public  ApplicationUser? ApplicationUser { get; set; }
        public ICollection<Application> Applications { get; } = new List<Application>();

    }
}
