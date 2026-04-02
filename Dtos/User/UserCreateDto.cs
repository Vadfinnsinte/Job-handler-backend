namespace JobHandlerAPI.DTOs.User
{
    public class UserCreateDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool EmploymentStatus { get; set; }
    }
}