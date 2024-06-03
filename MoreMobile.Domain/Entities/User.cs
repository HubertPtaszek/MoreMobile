using Microsoft.AspNetCore.Identity;

namespace MoreMobile.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public virtual ICollection<Warranty> Warranties { get; set; } = [];
    }
}