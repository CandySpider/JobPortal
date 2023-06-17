namespace JobPortal.Models
{
    public interface IEmployerRepository
    {
        public Employer GetEmployerById(int id);
        public ICollection<Employer> GetAllEmployers();
        public Employer GetEmployerByName(string name);
        public Employer GetEmployerByUserName(string userName);
        public void CreateEmployer(string userId);
        public void UpdatePhotoFileUrl (string idUser, string photoFileUrl);
        public void UpdateEmployerDetails(string idUser, string profileName, string profileDescription);
    }
}
