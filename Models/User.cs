namespace JobHandlerAPI.Models
{
    public class User
    {
        public Guid Id = Guid.NewGuid();
        
        public string Name { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool EmploymentStatus { get; set; } = false;

        public DateTime Created { get; set; } = DateTime.UtcNow;


    }
}
