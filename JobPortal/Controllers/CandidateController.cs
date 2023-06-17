using JobPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace JobPortal.Controllers
{
    public class CandidateController : Controller
    {   private readonly ICandidateRepository _candidateRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IWebHostEnvironment _serverEnvironment;
        public CandidateController (ICandidateRepository candidateRepository,IWebHostEnvironment serverEnvironment,IApplicationRepository applicationRepository)
        {
            _candidateRepository = candidateRepository;
            _applicationRepository = applicationRepository;
            _serverEnvironment = serverEnvironment;
        }
        [Authorize(Roles ="Candidate")]
        [HttpGet]
        public IActionResult Index()
        {  
            Candidate myCandidate = _candidateRepository.GetCandidateByUserName(User.Identity.Name);
            if (myCandidate == null)
                throw new Exception("No candidate");
            else
                return View(myCandidate);
        }

        [HttpPost]
        [Route("/CandidateController/ProfilePhotoUpload")]
        public IActionResult ProfilePhotoUpload(IFormFile photo)
        {  var photoFile= photo;
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
                var myCandidate = _candidateRepository.GetCandidateByUserName(User.Identity.Name);
                if (myCandidate == null) throw new Exception("The user isn't associated with the candidate role");
                _candidateRepository.UpdatePhotoFileUrl(myCandidate.ApplicationUserId,fileName);

            }
            else
                throw new Exception("The file is non-existent or empty!");
            var myString = new String("ProfilePhotoUpload"); 
            return RedirectToAction("UploadSuccessful");
        }

        [HttpPost]
        [Route("/CandidateController/ResumeFileUpload")]
        public IActionResult ResumeFileUpload(IFormFile resume)
        {
            //Check if the file type is ok
            string fileExtension = Path.GetExtension(resume.FileName).ToLower();
            if (fileExtension != ".pdf" && fileExtension != ".docx" && fileExtension != ".doc")
            {
                throw new Exception("Bad file format for the profile photo. ");
            }

            if (resume != null && resume.Length > 0)
            {   //Check if file path exists

                string resumeFolder = _serverEnvironment.WebRootPath + "/resumes";
                if (Directory.Exists(resumeFolder) == false)
                {
                    throw new DirectoryNotFoundException("The photos folder wasn't found!");
                }

                string fileName = User.Identity.Name + "resume" + fileExtension;
                string filePath = Path.Combine(resumeFolder, fileName);
                using (var myFileStream = new FileStream(filePath, FileMode.Create))  //creates or overwrites the existing file
                {
                    resume.CopyTo(myFileStream);
                }
                //Store the address for the file
                var myCandidate = _candidateRepository.GetCandidateByUserName(User.Identity.Name);
                if (myCandidate == null) throw new Exception("The user isn't associated with the candidate role");
                _candidateRepository.UpdateResumeFileUrl(myCandidate.ApplicationUserId, fileName);

            }
            else
                throw new Exception("IFormFile doesn't work");
            var myString = new String("ResumeFileUpload");
            return RedirectToAction("UploadSuccessful");
        }
        


        public IActionResult CreateProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProfile(Candidate myCandidate)
        {
            Candidate tempCandidate = _candidateRepository.GetCandidateByUserName(User.Identity.Name);
            _candidateRepository.UpdateCandidateDetails(tempCandidate.ApplicationUserId, myCandidate.CandidateName, myCandidate.PhoneNumber);
            return RedirectToAction("Index");
        }
      
        [Route("/CandidateController/UploadSuccessful")]
        public IActionResult UploadSuccessful(string myString) 
        { 
            return View(myString); 
        }
        [Authorize(Roles = "Candidate")]
        [HttpGet]
        public IActionResult JobApplications()
        {   Candidate myCandidate = _candidateRepository.GetCandidateByUserName(User.Identity.Name);
            List<Application> myApplications = (List<Application>)_applicationRepository.GetApplicationsByCandidateId(myCandidate.CandidateId);
            return View(myApplications);
        }

        [Authorize(Roles = "Candidate")]
        [Route("CandidateController/Withdraw/{id}")]
        public IActionResult Withdraw([FromRoute] int id)
        {
            _applicationRepository.DeleteApplication(id);
            return RedirectToAction("JobApplications");
        }
    }
}
