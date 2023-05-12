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

        public IEnumerable<Application> AllApplications
        {
            get
            {
                return _jobPortalDbContext.Applications;
            }
        }
        
        public IEnumerable<Application> GetApplicationsByJobId(int jobId)
        {
            return _jobPortalDbContext.Applications.Where(p => p.JobId == jobId);
        }

        public IEnumerable<Application> GetApplicationsByEmail (string email)
        {
            return null;
           // return _jobPortalDbContext.Applications.Where(p => p.CandidateProfil);
        }





    }
}
