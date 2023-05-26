using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
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
    }
}
