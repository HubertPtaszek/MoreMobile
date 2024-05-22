using System.ComponentModel.DataAnnotations;

namespace MoreMobile.Application.Models
{
    public class UserDTO
    {
        [Required(ErrorMessage = "FirstName is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string? PhoneNumber { get; set; }
    }
}
