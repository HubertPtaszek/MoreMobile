using Microsoft.AspNetCore.Identity;
using MoreMobile.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoreMobile.Domain.Entities
{
    public class UserBase : IdentityUser<Guid>
    {
    }

    public class User : UserBase
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Warranty> Warranties { get; set; } = [];

        public Guid? CompanyId { get; set; }

        public virtual Company? Company { get; set; }
    }

    public class Company : UserBase
    {
        [Required]
        public string CompanyName { get; set; }

        public virtual ICollection<User> Employees { get; set; } = [];
        public virtual ICollection<ServiceType> ServiceTypes { get; set; } = [];
        public virtual ICollection<Warranty> Warranties { get; set; } = [];
    }

    public class Admin : UserBase
    {
    }
}