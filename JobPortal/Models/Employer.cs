using System.ComponentModel.DataAnnotations;
namespace JobPortal.Models
{
    public class Employer
    {
        [Key]
        public int EmployerId { get; set; }
        public ICollection<Job>? Jobs{get; set;} 
    }
}
