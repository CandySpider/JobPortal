namespace JobPortal.Models
{
    public class JobRepository : IJobRepository
    {
        JobPortalDbContext _jobPortalDbContext;
        public JobRepository(JobPortalDbContext jobPortalDbContext) {
        _jobPortalDbContext = jobPortalDbContext;
        }
        public IEnumerable<Job> AllJobs
        {  
            get
            {
                return _jobPortalDbContext.Jobs;
            }
        }

        public IEnumerable<Job> JobsByLocation(string location)
        {
            return _jobPortalDbContext.Jobs.Where(p => p.Location == location);
        }

        public IEnumerable<Job> JobsOfType(string type)
        {
            return _jobPortalDbContext.Jobs.Where(p => p.JobType == type);
        }

        public IEnumerable<Job> JobsWithSalaryRange(int min, int max)
        {
            return _jobPortalDbContext.Jobs.Where(p => p.Salary >= min && p.Salary <= max);
        }
    }
}
