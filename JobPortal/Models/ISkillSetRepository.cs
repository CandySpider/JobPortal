namespace JobPortal.Models
{
    public interface ISkillSetRepository
    {
        public SkillSet GetSkillSetById(int skillSetId);
        public IEnumerable<SkillSet> AllSkillSets ();
        public void AddSkillSet(SkillSet skillSet,List<Skill> skills);
    }
}
