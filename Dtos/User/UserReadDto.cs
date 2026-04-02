namespace JobHandlerAPI.DTOs.User
{
    public class UserReadDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool EmploymentStatus { get; set; }
        public DateTime Created { get; set; }
    }
}