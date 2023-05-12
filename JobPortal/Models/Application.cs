using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }

        [Required]
        public int JobId { get; set; }

        [Required]
        public int CandidateId { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        public Job Job { get; set; } = null!;
        public Candidate Candidate { get; set; } = null!;
    }

}
