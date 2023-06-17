using Microsoft.EntityFrameworkCore;
namespace JobPortal.Models
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;

        public CandidateRepository(JobPortalDbContext jobPortalDbContext) 
        {
            _jobPortalDbContext = jobPortalDbContext;
        }
        public Candidate GetCandidateByUserName(string name)
        {
            if (name == null) throw new ArgumentNullException("Candidate Name cannot be null!");
            return _jobPortalDbContext.Candidates.Where(e => e.ApplicationUser.UserName == name).Include(e => e.Applications).FirstOrDefault();
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

        public void CreateCandidate(string idUser, string phoneNumber, string name)
        {
            Candidate myCandidate = new Candidate();
            myCandidate.CandidateName = name;
            myCandidate.ApplicationUserId = idUser;
            myCandidate.PhoneNumber = phoneNumber;
            _jobPortalDbContext.Candidates.Add(myCandidate);
            _jobPortalDbContext.SaveChanges();
        }


        public void UpdateResumeFileUrl(string idUser, string fileUrl)
        {
            _jobPortalDbContext.Candidates.Where(e => e.ApplicationUserId == idUser).FirstOrDefault().ResumeFileUrl = fileUrl;
            _jobPortalDbContext.SaveChanges();
        }

        public void UpdatePhotoFileUrl(string idUser, string fileUrl)
        {
            _jobPortalDbContext.Candidates.Where(e => e.ApplicationUserId == idUser).FirstOrDefault().ProfilePhotoUrl = fileUrl;
            _jobPortalDbContext.SaveChanges();
        }

        public void UpdateCandidateDetails(string idUser, string name, string phoneNumber)
        {
            Candidate myCandidate = _jobPortalDbContext.Candidates.Where(e => e.ApplicationUserId == idUser).FirstOrDefault();
            myCandidate.CandidateName = name;
            myCandidate.PhoneNumber = phoneNumber;
            _jobPortalDbContext.SaveChanges();
        }
    }
}
