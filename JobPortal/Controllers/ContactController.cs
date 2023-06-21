using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
