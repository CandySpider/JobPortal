using JobPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class EmployerController : Controller
    {
        IEmployerRepository _employerRepository;
        IJobRepository _jobRepository;
        IWebHostEnvironment _serverEnvironment;
        public EmployerController(IEmployerRepository employerRepository, IWebHostEnvironment serverEnvironment, IJobRepository jobRepository)
        {
            _employerRepository = employerRepository;
            _serverEnvironment = serverEnvironment;
            _jobRepository = jobRepository;
        }
        [Authorize(Roles = "Employer")]
        [HttpGet]
        public IActionResult Index()
        {
            Employer tempEmployer = _employerRepository.GetEmployerByUserName(User.Identity.Name);
            return View(tempEmployer);
        }
        [Authorize(Roles = "Employer")]
        [HttpGet]
        public IActionResult CreateProfile()
        {
            return View();
        }
        [Authorize(Roles = "Employer")]
        [HttpPost]
        [Route("/EmployerController/ProfilePhotoUpload")]
        public IActionResult ProfilePhotoUpload(IFormFile photo)
        {
            var photoFile = photo;
            //Check if the file type is ok
            string fileExtension = Path.GetExtension(photoFile.FileName).ToLower();
            if (fileExtension != ".jpeg" && fileExtension != ".jpg" && fileExtension != ".svg")
            {
                throw new Exception("Bad file format for the profile photo. ");
            }

            if (photoFile != null && photoFile.Length > 0)
            {   //Check if file path exists

                string photoFolder = _serverEnvironment.WebRootPath + "/images/ProfilePhotos";
                if (Directory.Exists(photoFolder) == false)
                {
                    throw new DirectoryNotFoundException("The photos folder wasn't found!");
                }

                string fileName = User.Identity.Name + "photo" + fileExtension;
                string filePath = Path.Combine(photoFolder, fileName);
                using (var myFileStream = new FileStream(filePath, FileMode.Create))  //creates or overwrites the existing file
                {
                    photoFile.CopyTo(myFileStream);
                }
                //Store the address for the file
                var myEmployer = _employerRepository.GetEmployerByUserName(User.Identity.Name);
                if (myEmployer == null) throw new Exception("The user isn't associated with the candidate role");
                _employerRepository.UpdatePhotoFileUrl(myEmployer.ApplicationUserId, fileName);

            }
            else
                throw new Exception("The file is non-existent or empty!");
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Employer")]
        [HttpPost]
        public IActionResult CreateProfile(Employer myEmployer)
        {  if (ModelState.IsValid == false) 
                throw new Exception("Form not completed correctly");
            Employer tempEmployer = _employerRepository.GetEmployerByUserName(User.Identity.Name);
            _employerRepository.UpdateEmployerDetails(tempEmployer.ApplicationUserId, myEmployer.ProfileName, myEmployer.ProfileDescription);
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "Employer")]
        [HttpGet]
        public IActionResult PostedJobs()
        {
            Employer myEmployer = _employerRepository.GetEmployerByUserName(User.Identity.Name);
            List<Job> myJobList = _jobRepository.GetJobsByEmployer(myEmployer);
            return View(myJobList);
        }

        [Authorize(Roles = "Employer")]
        [Route("/EmployerController/DeleteJob/{id}")]
        public IActionResult DeleteJobPosting([FromRoute] int id)
        {
            Job myJob = _jobRepository.GetJobById(id);
            if (myJob != null)
            {
                _jobRepository.DeleteJob(myJob);
            }
            return RedirectToAction("PostedJobs");
        }

    }
}
