using JobPortal.Controllers;
using JobPortal.Models;
using JobPortal.ViewModels;
using JobPortalTests.Mocks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using System.Data;
using Moq;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

namespace JobPortalTests.Controllers
{
    public class JobsControllerTests
    {
        /*[Fact]
        public void Add_A_Job()
        {
            //arrange
            var mockJobRepository = RepositoryMocks.GetJobRepository();
            var skillRepository = RepositoryMocks.GetSkillRepository();
            var skillSetRepository = RepositoryMocks.GetSkillSetRepository();
            var employerRepository = RepositoryMocks.GetEmployerRepository();
            var candidateRepository = RepositoryMocks.GetCandidateRepository();
            var applicationRepository = RepositoryMocks.GetApplicationRepository();
            var jobsController = new JobsController(mockJobRepository.Object, skillRepository.Object, skillSetRepository.Object,
                employerRepository.Object, applicationRepository.Object, candidateRepository.Object);
          

          
            Skill mySkill1 = new Skill { SkillName = "C" };
            Skill mySkill2 = new Skill { SkillName = "Outgoing" };
            Skill mySkill3 = new Skill { SkillName = "Javascript" };
            SkillSet mySkillSet1 = new SkillSet();
            mySkillSet1.Skills = new List<Skill>() { mySkill1, mySkill2, mySkill3 };
            Employer myEmployer = new Employer();
            Job job = new Job{JobTitle = "Junior Software Engineer",
                          CompanyName = "BMW",
                          JobDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sem lectus, vulputate nec vulputate ac, consectetur rutrum lorem. Etiam dignissim nec sem ut ultricies. Proin quam elit, rhoncus sed eleifend at, mattis vitae enim. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nunc sit amet tincidunt elit, ac vulputate urna. Maecenas scelerisque commodo dolor eu eleifend. Aliquam aliquam magna lorem, et egestas nibh feugiat sed. Integer erat nulla, mollis sed egestas nec, aliquet id risus. Vivamus pharetra tortor condimentum ex imperdiet venenatis. Nunc mollis lorem quis orci condimentum gravida. Nunc imperdiet purus ipsum, at volutpat ipsum bibendum eu. Nullam ex diam, convallis non interdum nec, imperdiet sit amet elit. Fusce tempus enim in ligula viverra sagittis. Nullam in neque nibh.",
                          Location = "Bucharest",
                          Salary = 5500,
                          CreatedDate = new DateTime(2018, 7, 17, 12, 31, 40),
                          ApplicationDeadline = new DateTime(2022, 2, 7, 12, 31, 40),
                          JobType = "Remote",
                          SkillSet = mySkillSet1,
                          Employer = myEmployer,
            };
            var jobPostingViewModel = new JobPostingViewModel();
            jobPostingViewModel.Job = job;
            jobPostingViewModel.SkillList = new List<Skill> {mySkill1, mySkill2, mySkill3 };
            //act
            var result = jobsController.Post(jobPostingViewModel);
            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<JobPostingViewModel>(viewResult.ViewData.Model);
            Assert.Equal(4, model.Count);
        }*/
        [Fact]
        public void Remove_A_Job() 
        {
        
        }
        [Fact]
        public void Check_The_Number_Of_Jobs()
        {
            //arrange
            var mockJobRepository = RepositoryMocks.GetJobRepository();
            var skillRepository = RepositoryMocks.GetSkillRepository();
            var skillSetRepository = RepositoryMocks.GetSkillSetRepository();
            var employerRepository = RepositoryMocks.GetEmployerRepository();
            var candidateRepository = RepositoryMocks.GetCandidateRepository();
            var applicationRepository = RepositoryMocks.GetApplicationRepository();
            var jobsController = new JobsController(mockJobRepository.Object, skillRepository.Object, skillSetRepository.Object,
                employerRepository.Object, applicationRepository.Object, candidateRepository.Object);
            //act
            var result = jobsController.Index();
            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Job>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count);
        }
    }
}
