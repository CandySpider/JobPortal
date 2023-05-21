using Microsoft.EntityFrameworkCore;

namespace JobPortal.Models
{
    public class SkillRepository : ISkillRepository
    {
        JobPortalDbContext _jobPortalDbContext;
       public SkillRepository(JobPortalDbContext jobPortalDbContext) {
        _jobPortalDbContext = jobPortalDbContext;
        }

        public void AddSkill(Skill mySkill)
        {   if (_jobPortalDbContext.Skills.Where(e => e.SkillName == mySkill.SkillName).FirstOrDefault() == null)
            { _jobPortalDbContext.Skills.Add(mySkill); }
            _jobPortalDbContext.SaveChanges();
        }

        public IEnumerable<Skill> GetAll()
        {
            return _jobPortalDbContext.Skills;
        }

        public IEnumerable<Skill> GetSkillsByName(string skillName)
        {
            List<Skill> mySkills = new List<Skill>();
            foreach (var i in _jobPortalDbContext.Skills)
            {   
                if(i.SkillName == skillName)
                mySkills.Add(i);
            }
            return mySkills;
        }

        public void RemoveSkill(Skill skill)
        {
            throw new NotImplementedException();
        }
    }
}
