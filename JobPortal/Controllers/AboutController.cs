using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
