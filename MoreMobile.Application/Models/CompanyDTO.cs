using MoreMobile.Domain.Entities;
using MoreMobile.Resources.Core;
using System.ComponentModel.DataAnnotations;

namespace MoreMobile.Application.Models
{
    public class CompanyDTO
    {
        [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public string? Email { get; set; }

        [Required(ErrorMessageResourceName = "CompanyNameRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public string CompanyName { get; set; }

        public virtual ICollection<UserDTO> Employees { get; set; } = [];
        public virtual ICollection<ServiceTypeDTO> ServiceTypes { get; set; } = [];
        public virtual ICollection<WarrantyDTO> Warranties { get; set; } = [];
    }
}