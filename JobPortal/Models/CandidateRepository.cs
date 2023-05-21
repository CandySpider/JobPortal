namespace JobPortal.Models
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;

        public CandidateRepository(JobPortalDbContext jobPortalDbContext) 
        {
            _jobPortalDbContext = jobPortalDbContext;
        }
        public Candidate GetCandidateByEmail(string email)
        {    
            if (email == null) throw new ArgumentNullException("Candidate Email cannot be null!");
            return _jobPortalDbContext.Candidates.Where(e => e.EmailAddress == email).First();
        }

        public ICollection<Candidate> GetCandidateByName(string name)
        {  
            if (name == null) throw new ArgumentNullException("Candidate Name cannot be null!");
            return _jobPortalDbContext.Candidates.Where(e => e.CandidateName.Contains(name)).ToList();
        }

        public ICollection<Candidate> GetCandidates()
        {  
            return _jobPortalDbContext.Candidates.ToList();
        }
    }
}
