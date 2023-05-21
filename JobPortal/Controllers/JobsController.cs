using JobPortal.Models;
using JobPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JobPortal.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobRepository _jobRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ISkillSetRepository _skillSetRepository;
    
        public JobsController (IJobRepository jobRepository, ISkillRepository skillRepository, ISkillSetRepository skillSetRepository)
        {
            _jobRepository = jobRepository;
            _skillRepository = skillRepository;
            _skillSetRepository = skillSetRepository;
        }
        [HttpGet]
        public ViewResult Index()
        {    List<Job> myJobList = new List <Job> (_jobRepository.AllJobs);
            return View(myJobList);
        }
        public IActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Post(JobPostingViewModel myJopPostingViewModel)
        {     
                Employer employer = new Employer();
                _jobRepository.CreateJob(myJopPostingViewModel.Job, myJopPostingViewModel.SkillList, employer);
                return RedirectToAction("PostComplete");
            
            
            //return View(myJopPostingViewModel);

        }
        public IActionResult PostComplete()
        {
            ViewBag.JobPostingCompleteMessage = "Post submitted!";
            return View();
        }
    }
}
