using MoreMobile.Resources.Core;
using System.ComponentModel.DataAnnotations;

namespace MoreMobile.Application.Models
{
    public class UserDTO
    {
        [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public string? Email { get; set; }

        [Required(ErrorMessageResourceName = "FirstNameRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public string? FirstName { get; set; }

        [Required(ErrorMessageResourceName = "LastNameRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public string? LastName { get; set; }

        [Required(ErrorMessageResourceName = "PhoneNumberRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public string? PhoneNumber { get; set; }

        public Guid? CompanyId { get; set; }
    }
}