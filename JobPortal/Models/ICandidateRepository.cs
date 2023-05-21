namespace JobPortal.Models
{
    public interface ICandidateRepository
    { 
        ICollection<Candidate> GetCandidates();
        ICollection<Candidate> GetCandidateByName(string name);
        Candidate GetCandidateByEmail (string email);
    }
}
