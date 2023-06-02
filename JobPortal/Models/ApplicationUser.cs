using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Something { get; set; } = string.Empty;

        public Candidate? Candidate { get; set; }
        public Employer? Employer { get; set; }

        

    }
}
