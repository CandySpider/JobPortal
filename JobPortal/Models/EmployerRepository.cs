namespace JobPortal.Models
{
    public class EmployerRepository : IEmployerRepository
    {
        JobPortalDbContext _jobPortalDbContext;
        public EmployerRepository(JobPortalDbContext jobPortalDbContext)
        {
            _jobPortalDbContext = jobPortalDbContext;
        }

        public void CreateEmployer(string userId)
        {
            Employer myEmployer = new Employer();
            myEmployer.ApplicationUserId = userId;
            _jobPortalDbContext.Employers.Add(myEmployer);
            _jobPortalDbContext.SaveChanges();
        }

        public ICollection<Employer> GetAllEmployers()
        {
            return _jobPortalDbContext.Employers.ToList();
        }

        public Employer GetEmployerById(int id)
        {
            return _jobPortalDbContext.Employers.Where(e => e.EmployerId == id).First();
        }

        public Employer GetEmployerByName(string name)
        {
            return _jobPortalDbContext.Employers.Where(e => e.ProfileName == name).First();
        }
    }
}
