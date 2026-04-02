using System.ComponentModel.DataAnnotations;

namespace JobHandlerAPI.Dtos
{
    public class UserUpdateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool EmploymentStatus { get; set; }
    }
}
