namespace JobPortal.Models
{
    public interface IApplicationRepository
    {
        IEnumerable<Application>? AllApplications { get; }
        IEnumerable<Application> GetApplicationsByJobId(int id);
        
    }
}
