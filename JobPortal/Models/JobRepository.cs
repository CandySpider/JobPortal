using Microsoft.EntityFrameworkCore;

namespace JobPortal.Models
{
    public class JobRepository : IJobRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;
        private readonly ISkillSetRepository _skillSetRepository;
        private readonly ISkillRepository _skillRepository;
        public JobRepository(JobPortalDbContext jobPortalDbContext, ISkillSetRepository skillSetRepository,ISkillRepository skillRepository) {
        _jobPortalDbContext = jobPortalDbContext;
        _skillSetRepository = skillSetRepository;
        _skillRepository = skillRepository;
        }
        public IEnumerable<Job> AllJobs
        {  
            get
            {
                return _jobPortalDbContext.Jobs.Include(e => e.Employer).Include(e => e.SkillSet).ThenInclude(e => e.Skills);
            }
        }
        public List<Job> GetJobsByEmployer(Employer employer)
        {  if (employer == null)
                return new List<Job>();
            return _jobPortalDbContext.Jobs.Where(e => e.Employer == employer).Include(e => e.SkillSet).ThenInclude(e => e.Skills).ToList();

        }
       
        public void CreateJob(Job myJob,List<Skill> mySkillList,Employer myEmployer)
        {    
            myJob.CreatedDate = DateTime.Now;
            SkillSet mySkillSet = new SkillSet();
            foreach (Skill skill in mySkillList)
            {
                _skillRepository.AddSkill(skill);

            }
            _skillSetRepository.AddSkillSet(mySkillSet,mySkillList);
            
            myJob.SkillSet = mySkillSet;
            myJob.Employer = myEmployer;
            _jobPortalDbContext.Jobs.Add(myJob);
            _jobPortalDbContext.SaveChanges();
        }
        
        public void DeleteJob(Job job)
        {
            _jobPortalDbContext.Jobs.Remove(job);
            _jobPortalDbContext.SaveChanges();
        }

        public Job GetJobById(int id)
        {
            return _jobPortalDbContext.Jobs.Where(p => p.JobId == id).FirstOrDefault();
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
