namespace JobPortal.Models
{
    public interface ICandidateRepository
    { 
        ICollection<Candidate> GetCandidates();
        ICollection<Candidate> GetCandidateByName(string name);
        Candidate GetCandidateByUserName(string name);

        void CreateCandidate(string idUser, string phoneNumber, string name);
        void UpdateResumeFileUrl (string idUser, string fileUrl);
        void UpdatePhotoFileUrl (string idUser, string fileUrl);

        void UpdateCandidateDetails(string idUser, string name, string phoneNumber);
    }
}
