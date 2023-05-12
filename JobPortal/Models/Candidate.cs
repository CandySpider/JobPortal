using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }

        public ICollection<Application> Applications { get; } =new List<Application>();
        public CandidateProfile? CandidateProfile { get; set; }
    }
}
