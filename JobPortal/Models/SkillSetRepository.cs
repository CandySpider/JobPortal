namespace JobPortal.Models
{
    public class SkillSetRepository:ISkillSetRepository
    {
        private readonly JobPortalDbContext _jobPortalDbContext;
        private readonly ISkillRepository _skillRepository;
        public SkillSetRepository(JobPortalDbContext jobPortalDbContext, ISkillRepository skillRepository) 
        {
            _jobPortalDbContext = jobPortalDbContext;
            _skillRepository = skillRepository;
        }

        public void AddSkillSet(SkillSet skillSet, List<Skill>? skills)
        {   if (skills != null)
            {
                List<Skill> filteredSkillList = new List<Skill>();
                foreach (var i in skills)
                {  if (i.SkillName == null)
                        continue;
                    if (_skillRepository.GetSkillsByName(i.SkillName) == null || _skillRepository.GetSkillsByName(i.SkillName).Any() == false)
                    {
                       _skillRepository.AddSkill(i);
                        filteredSkillList.Add(i);
                    }
                    else
                    {
                        Skill existingSkill = _skillRepository.GetSkillsByName(i.SkillName).First();
                        filteredSkillList.Add(existingSkill);
                    }
                }
                skillSet.Skills = filteredSkillList;
            }
            _jobPortalDbContext.SkillSets.Add(skillSet);
            _jobPortalDbContext.SaveChanges();
        }

        public IEnumerable<SkillSet> AllSkillSets ()
        {

            
                return _jobPortalDbContext.SkillSets;
                        
        }

        public SkillSet GetSkillSetById(int skillSetId)
        {
            return _jobPortalDbContext.SkillSets.Where(p => p.SkillSetId == skillSetId).First();
        }

       
    }
}
