using JobPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class EmployerController : Controller
    {  
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProfile(Employer myEmployer)
        {
            return new JsonResult(true);
        }
    }
}
