namespace JobPortal.Models
{
    public interface IApplicationRepository
    {
        List<Application> GetApplicationsByJobId(int id);
        List<Application> GetApplicationsByCandidateId(int candidateId);
        void CreateApplication (Job job, Candidate candidate);
        public void DeleteApplication(int applicationId);


    }
}
