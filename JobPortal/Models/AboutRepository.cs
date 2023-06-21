namespace JobPortal.Models
{
    public class AboutRepository : IAboutRepository
    {
        JobPortalDbContext _jobPortalDbContext;
        public AboutRepository(JobPortalDbContext jobPortalDbContext) {
        _jobPortalDbContext = jobPortalDbContext;
        
        }
        public string GetText1()
        {  if (_jobPortalDbContext.Abouts.FirstOrDefault() == null)
                return string.Empty;
            return _jobPortalDbContext.Abouts.First().Info1;
        }

        public string GetText2()
        {
            if (_jobPortalDbContext.Abouts.FirstOrDefault() == null)
                return string.Empty;
            return _jobPortalDbContext.Abouts.First().Info2;
        }

        public void InputText(string text1, string text2)
        {
            if(_jobPortalDbContext.Abouts.Any() == false)
            {
                About myAbout = new About();
                myAbout.Info1 = text1;
                myAbout.Info2 = text2;
                _jobPortalDbContext.Abouts.Add(myAbout);
            }
            else
            {
                _jobPortalDbContext.Abouts.First().Info1 = text1;
                _jobPortalDbContext.Abouts.First().Info2 = text2;
            }
            _jobPortalDbContext.SaveChanges();

        }
    }
}
