using JobPortal.Models;
using JobPortal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobRepository _jobRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ISkillSetRepository _skillSetRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly ICandidateRepository _candidateRepository;
    
        public JobsController (IJobRepository jobRepository, ISkillRepository skillRepository, ISkillSetRepository skillSetRepository, IEmployerRepository employerRepository, IApplicationRepository applicationRepository, ICandidateRepository candidateRepository)
        {
            _jobRepository = jobRepository;
            _skillRepository = skillRepository;
            _skillSetRepository = skillSetRepository;
            _employerRepository = employerRepository;
            _applicationRepository = applicationRepository;
            _candidateRepository = candidateRepository;
        }
        [HttpGet]
        public ViewResult Index()
        {    List<Job> myJobList = new List <Job> (_jobRepository.AllJobs);
            return View(myJobList);
        }

        [Authorize(Roles = "Employer")]
        [HttpGet]
        public IActionResult Post()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        [HttpPost]
        public IActionResult Post(JobPostingViewModel myJopPostingViewModel)
        {   
            var myEmployer = _employerRepository.GetEmployerByUserName(User.Identity.Name);
            if (ModelState.IsValid && myEmployer!=null)
            {


                _jobRepository.CreateJob(myJopPostingViewModel.Job, myJopPostingViewModel.SkillList, myEmployer);
                return RedirectToAction("PostComplete");
            }
            
            return View(myJopPostingViewModel);

        }
        public IActionResult PostComplete()
        {
            ViewBag.JobPostingCompleteMessage = "Post submitted!";
            return View();
        }
       

        [Authorize(Roles = "Candidate")]
        [Route("Jobs/Apply/{id}")]
        [HttpGet]
        public IActionResult Apply([FromRoute] int id)
        {  
           var desiredJob = _jobRepository.GetJobById(id);
            var candidate = _candidateRepository.GetCandidateByUserName(User.Identity.Name); 
            if (desiredJob!=null)
            {
                _applicationRepository.CreateApplication(desiredJob,candidate);
                return RedirectToAction("ApplicationSuccessful");
            }
            return View();
        }
        [Authorize(Roles = "Candidate")]
        [HttpGet]
        public IActionResult ApplicationSuccessful()
        {
            return View();
        }
    }
}
