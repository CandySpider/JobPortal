using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
