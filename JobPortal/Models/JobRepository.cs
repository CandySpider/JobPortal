using Microsoft.EntityFrameworkCore;

namespace JobPortal.Models
{
    public class JobRepository : IJobRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;
        private readonly IEmployerRepository _employerRepository;
        private readonly ISkillSetRepository _skillSetRepository;
        private readonly ISkillRepository _skillRepository;
        public JobRepository(JobPortalDbContext jobPortalDbContext,IEmployerRepository employerRepository, ISkillSetRepository skillSetRepository,ISkillRepository skillRepository) {
        _jobPortalDbContext = jobPortalDbContext;
        _employerRepository = employerRepository;
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

        public void CreateJob(Job myJob,List<Skill> mySkillList,Employer myEmployer)
        {    
            myJob.CreatedDate = DateTime.Now;
            SkillSet mySkillSet = new SkillSet();
          /*  foreach (Skill skill in mySkillList)
            {  
                skill.SkillSets = (ICollection<SkillSet>)mySkillSet;
                _skillRepository.AddSkill(skill);
                
            }*/
            _skillSetRepository.AddSkillSet(mySkillSet,mySkillList);
            
            myJob.SkillSet = mySkillSet;
            myJob.Employer = myEmployer;
            _jobPortalDbContext.Jobs.Add(myJob);
            _jobPortalDbContext.SaveChanges();
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
