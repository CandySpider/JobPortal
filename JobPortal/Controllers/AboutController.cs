using Microsoft.AspNetCore.Mvc;
using JobPortal.Models;
using JobPortal.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace JobPortal.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutRepository _aboutRepository;
        public AboutController(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
        
        [HttpGet]
        public IActionResult Index()
        {  
            AboutViewModel viewModel = new AboutViewModel();
            viewModel.Info1 = _aboutRepository.GetText1();
            viewModel.Info2 = _aboutRepository.GetText2();
            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Update() 
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update(AboutViewModel aboutViewModel)
        {   _aboutRepository.InputText(aboutViewModel.Info1, aboutViewModel.Info2);
            return RedirectToAction("Index");
        }
    }
}
