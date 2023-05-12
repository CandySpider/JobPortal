using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class SkillSet
    {
        [Key]
        public int SkillSetId {get; set;}
        public  ICollection<Skill>? Skills { get; set; }
    }
}
