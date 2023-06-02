using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class Employer
    {
        [Key]
        [BindNever]
        public int EmployerId { get; set; }
        public string ProfilePictureUrl { get; set; } = string.Empty;
        [Required]
        public string ProfileName { get; set; } = string.Empty;
        
        public string ProfileDescription { get; set; } = string.Empty;
        public ICollection<Job>? Jobs{get; set;}
        public string? ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser? ApplicationUser { get; set; }
    }
}
