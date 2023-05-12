using JobPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobRepository _jobRepository;
        public JobsController (IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public ViewResult Index()
        {    List<Job> myJobList = new List <Job> (_jobRepository.AllJobs);
             //List<Skill> mySkillList = myJobList.ToList ();
             //add skills repositories
            return View(myJobList);
        }
    }
}
