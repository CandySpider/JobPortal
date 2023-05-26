using JobPortal.Models;

namespace JobPortal.ViewModels
{
    public class JobPostingViewModel
    {
        public List<Skill> SkillList { get; set;  } = new List<Skill>();
        public Job Job { get; set;  } = new Job();

       
    }
}
