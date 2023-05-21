namespace JobPortal.Models
{
    public interface IJobRepository
    {
        IEnumerable<Job> AllJobs { get;}
        IEnumerable<Job> JobsWithSalaryRange(int min, int max);
        IEnumerable<Job> JobsOfType (string type);
        IEnumerable<Job> JobsByLocation (string location);
        void CreateJob (Job job, List<Skill> skillList, Employer employer);
    }
}
