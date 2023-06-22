using JobPortal.Controllers;
using JobPortal.ViewModels;
using JobPortalTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalTests.Controllers
{
   public class AboutControllerTests
    {
        [Fact]
        public void Check_Paragraphs ()
        {
            //arrange
            var mockAboutRepository = RepositoryMocks.GetAboutRepository();
            var aboutController = new AboutController(mockAboutRepository.Object);
            //act 
            var result = aboutController.Index();
            //assert 
            var viewResult = Assert.IsType<ViewResult>(result);
            var aboutViewModel = Assert.IsAssignableFrom<AboutViewModel>(viewResult.ViewData.Model);
            Assert.NotNull(aboutViewModel);
        }
        [Fact]
        public void Check_Paragraphs2()
        {
            //arrange
            var mockAboutRepository = RepositoryMocks.GetAboutRepository();
            var aboutController = new AboutController(mockAboutRepository.Object);
            //act 
            var result = aboutController.Index();
            //assert 
            var viewResult = Assert.IsType<ViewResult>(result);
            var aboutViewModel = Assert.IsAssignableFrom<AboutViewModel>(viewResult.ViewData.Model);
            var myAboutViewModel = new AboutViewModel();
            myAboutViewModel.Info1 = "Are you looking for your dream job? Look no further!";
            myAboutViewModel.Info2 = "Finding the right talent for your organization is crucial for success.";
            Assert.Equal(myAboutViewModel.Info1, aboutViewModel.Info1);
            Assert.Equal(myAboutViewModel.Info2, aboutViewModel.Info2);
        }
    }
}
