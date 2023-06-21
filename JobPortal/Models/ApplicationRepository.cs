using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Models
{
    public class ApplicationRepository:IApplicationRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;
        public ApplicationRepository(JobPortalDbContext jobPortalDbContext) {
            _jobPortalDbContext = jobPortalDbContext;
        }


        public void CreateApplication(Job job, Candidate candidate)
        {
            Application myApplication = new Application();
            myApplication.Job = job;
            myApplication.Candidate = candidate;
            myApplication.ApplicationDate = DateTime.Now;
            if(_jobPortalDbContext.Applications.Where(e => e.Job == job && e.Candidate == candidate).Count() == 0 )
            {
                _jobPortalDbContext.Applications.Add(myApplication);
                _jobPortalDbContext.SaveChanges();
            }
        }

        public List<Application> GetApplicationsByJobId(int jobId)
        {
            return _jobPortalDbContext.Applications.Where(p => p.JobId == jobId).Include(e => e.Candidate).ToList();
        }
        
        public List<Application> GetApplicationsByCandidateId(int candidateId) 
        {
            return _jobPortalDbContext.Applications.Where(e => e.CandidateId == candidateId).Include(e => e.Job).ToList();
        }

        public void DeleteApplication (int applicationId)
        {    
            Application myApplication = _jobPortalDbContext.Applications.Where(e => e.ApplicationId == applicationId).FirstOrDefault();
            _jobPortalDbContext.Applications.Remove(myApplication);
            _jobPortalDbContext.SaveChanges();
        }






    }
}
