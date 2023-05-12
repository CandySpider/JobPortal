using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class CompanyProfile
    {
        [Key]
        public int CompanyProfileId { get; set; }
        [Required]
        public int EmployerId { get; set; }
        public Employer Employer { get; set; } = null!;
    }
}
