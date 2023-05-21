namespace JobPortal.Models
{
    public interface ISkillRepository
    {
        IEnumerable<Skill> GetAll();
        IEnumerable<Skill> GetSkillsByName(string skillName);
        void AddSkill(Skill skill); 
        void RemoveSkill(Skill skill);
    }
}
