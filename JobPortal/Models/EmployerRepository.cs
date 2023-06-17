using System.Xml.Linq;

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

        public Employer GetEmployerByUserName(string userName)
        {
            if (userName == null) throw new ArgumentNullException("Employer Name cannot be null!");
            return _jobPortalDbContext.Employers.Where(e => e.ApplicationUser.UserName == userName).FirstOrDefault();
        }

        public void UpdateEmployerDetails(string idUser, string profileName, string profileDescription)
        {  if(idUser == null) throw new ArgumentNullException("User Id cannot be null!");
           if (profileDescription == null) throw new ArgumentNullException("Profile description cannot be null!");
           if(profileName == null) throw new ArgumentNullException("Profile name cannot be null!");
            Employer myEmployer = _jobPortalDbContext.Employers.Where(e => e.ApplicationUserId == idUser).FirstOrDefault();
            myEmployer.ProfileDescription = profileDescription;
            myEmployer.ProfileName = profileName;
            _jobPortalDbContext.SaveChanges();
        }

        public void UpdatePhotoFileUrl(string idUser, string photoFileUrl)
        {
            _jobPortalDbContext.Employers.Where(e => e.ApplicationUserId == idUser).FirstOrDefault().ProfilePictureUrl = photoFileUrl;
            _jobPortalDbContext.SaveChanges();
        }
    }
}
