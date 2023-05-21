namespace JobPortal.Models
{
    public interface IEmployerRepository
    {
        public Employer GetEmployerById(int id);
        public ICollection<Employer> GetAllEmployers();
        public Employer GetEmployerByName(string name);
    }
}
