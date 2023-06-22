using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using JobPortal.Models;
using NuGet.Packaging.Signing;
using Microsoft.AspNetCore.Identity;

namespace JobPortalTests.Mocks
{
    internal class RepositoryMocks
    {
        public static Mock<IJobRepository> GetJobRepository()
        {
            Skill mySkill1 = new Skill { SkillName = "C" };
            Skill mySkill2 = new Skill { SkillName = "Outgoing" };
            Skill mySkill3 = new Skill { SkillName = "Javascript" };
            Skill mySkill4 = new Skill { SkillName = "Git" };
            Skill mySkill5 = new Skill { SkillName = "Agile" };
            Skill mySkill6 = new Skill { SkillName = "Teamwork" };
            Skill mySkill7 = new Skill { SkillName = "HTML" };
            Skill mySkill8 = new Skill { SkillName = "English" };
            SkillSet mySkillSet1 = new SkillSet();
            SkillSet mySkillSet2 = new SkillSet();
            SkillSet mySkillSet3 = new SkillSet();
            Employer myEmployer1 = new Employer();
            Employer myEmployer2 = new Employer();
            Employer myEmployer3 = new Employer();
            mySkillSet1.Skills = new List<Skill>() { mySkill1, mySkill4, mySkill5 };
            mySkillSet2.Skills = new List<Skill>() { mySkill2, mySkill6, mySkill8 };
            mySkillSet3.Skills = new List<Skill>() { mySkill2, mySkill6 };
            myEmployer1.ProfilePictureUrl = "images/SVGs/bmw.svg";
            myEmployer2.ProfilePictureUrl = "images/SVGs/coca-cola-6.svg";
            myEmployer3.ProfilePictureUrl = "images/SVGs/audi-11.svg";
            var jobs = new List<Job> {
                new Job
                {
                       JobTitle = "Junior Software Engineer",
                          CompanyName = "BMW",
                          JobDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sem lectus, vulputate nec vulputate ac, consectetur rutrum lorem. Etiam dignissim nec sem ut ultricies. Proin quam elit, rhoncus sed eleifend at, mattis vitae enim. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nunc sit amet tincidunt elit, ac vulputate urna. Maecenas scelerisque commodo dolor eu eleifend. Aliquam aliquam magna lorem, et egestas nibh feugiat sed. Integer erat nulla, mollis sed egestas nec, aliquet id risus. Vivamus pharetra tortor condimentum ex imperdiet venenatis. Nunc mollis lorem quis orci condimentum gravida. Nunc imperdiet purus ipsum, at volutpat ipsum bibendum eu. Nullam ex diam, convallis non interdum nec, imperdiet sit amet elit. Fusce tempus enim in ligula viverra sagittis. Nullam in neque nibh.",
                          Location = "Bucharest",
                          Salary = 5500,
                          CreatedDate = new DateTime(2018, 7, 17, 12, 31, 40),
                          ApplicationDeadline = new DateTime(2022, 2, 7, 12, 31, 40),
                          JobType = "Remote",
                          SkillSet = mySkillSet1,
                          Employer = myEmployer1,
                },
                new Job
                {
                     JobTitle = "Server",
                          CompanyName = "Coca-cola",
                          JobDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sem lectus, vulputate nec vulputate ac, consectetur rutrum lorem. Etiam dignissim nec sem ut ultricies. Proin quam elit, rhoncus sed eleifend at, mattis vitae enim. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nunc sit amet tincidunt elit, ac vulputate urna. Maecenas scelerisque commodo dolor eu eleifend. Aliquam aliquam magna lorem, et egestas nibh feugiat sed. Integer erat nulla, mollis sed egestas nec, aliquet id risus. Vivamus pharetra tortor condimentum ex imperdiet venenatis. Nunc mollis lorem quis orci condimentum gravida. Nunc imperdiet purus ipsum, at volutpat ipsum bibendum eu. Nullam ex diam, convallis non interdum nec, imperdiet sit amet elit. Fusce tempus enim in ligula viverra sagittis. Nullam in neque nibh.",
                          Location = "Bucharest",
                          Salary = 3000,
                          CreatedDate = new DateTime(2019, 2, 17, 2, 1, 25),
                          ApplicationDeadline = new DateTime(2023, 1, 1, 7, 31, 40),
                          JobType = "Hybrid",
                          SkillSet = mySkillSet2,
                          Employer = myEmployer2
                },
                new Job
                {
                      JobTitle = "Junior Mechanical Engineer",
                            CompanyName = "Audi",
                            JobDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sem lectus, vulputate nec vulputate ac, consectetur rutrum lorem. Etiam dignissim nec sem ut ultricies. Proin quam elit, rhoncus sed eleifend at, mattis vitae enim. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nunc sit amet tincidunt elit, ac vulputate urna. Maecenas scelerisque commodo dolor eu eleifend. Aliquam aliquam magna lorem, et egestas nibh feugiat sed. Integer erat nulla, mollis sed egestas nec, aliquet id risus. Vivamus pharetra tortor condimentum ex imperdiet venenatis. Nunc mollis lorem quis orci condimentum gravida. Nunc imperdiet purus ipsum, at volutpat ipsum bibendum eu. Nullam ex diam, convallis non interdum nec, imperdiet sit amet elit. Fusce tempus enim in ligula viverra sagittis. Nullam in neque nibh.",
                            Location = "Timisoara",
                            Salary = 4000,
                            CreatedDate = new DateTime(2018, 7, 17, 12, 31, 40),
                            ApplicationDeadline = new DateTime(2022, 2, 7, 12, 31, 40),
                            JobType = "Remote",
                            SkillSet = mySkillSet3,
                            Employer = myEmployer3
                }
                };
            var mockJobRepository = new Mock<IJobRepository>();
            mockJobRepository.Setup(repo => repo.AllJobs).Returns(jobs);
            return mockJobRepository;
        }

        public static Mock<ICandidateRepository> GetCandidateRepository()
        {
            var mockCandidateRepository = new Mock<ICandidateRepository>();
            return mockCandidateRepository;
        }
        public static Mock<IAboutRepository> GetAboutRepository()
        {
            string myText1 = "Are you looking for your dream job? Look no further!"; 
            string myText2 = "Finding the right talent for your organization is crucial for success.";
            var mockAboutRepository = new Mock<IAboutRepository>();
            mockAboutRepository.Setup(repo => repo.GetText1()).Returns(myText1);
            mockAboutRepository.Setup(repo => repo.GetText2()).Returns(myText2);
            return mockAboutRepository;
        }
        public static Mock<IApplicationRepository> GetApplicationRepository()
        {
            var mockApplicationRepository = new Mock<IApplicationRepository>();
            return mockApplicationRepository;
        }
        public static Mock<ISkillRepository> GetSkillRepository()
        { 
            var mockSkillRepository = new Mock<ISkillRepository>();
            return mockSkillRepository;
        }
        public static Mock<ISkillSetRepository> GetSkillSetRepository()
        {
            var mockSkillSetRepository = new Mock<ISkillSetRepository>();
            return mockSkillSetRepository;
        }

        public static Mock<IEmployerRepository> GetEmployerRepository()
        {
            var employerRepository = new Mock<IEmployerRepository>();
            Employer myEmployer = new Employer();
            employerRepository.Setup(repo => repo.GetEmployerByUserName("z")).Returns(myEmployer);
            return employerRepository;
        }
    }
}

