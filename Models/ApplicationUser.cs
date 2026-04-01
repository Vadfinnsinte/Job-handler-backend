using Microsoft.AspNetCore.Identity;
namespace JobHandlerAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public bool EmploymentStatus { get; set; } = false;

        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
