using System.ComponentModel.DataAnnotations;

namespace JobHandlerAPI.Dtos
{
    public class ChangePasswordDTO
    {

        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$")]
        public string NewPassword { get; set; }
    }
}