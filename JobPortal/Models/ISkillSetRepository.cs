namespace JobPortal.Models
{
    public interface ISkillSetRepository
    {
        SkillSet GetSkillSetById(int skillSetId);
        IEnumerable<SkillSet> AllSkillSets ();
        void AddSkillSet(SkillSet skillSet,List<Skill> skills);
    }
}
