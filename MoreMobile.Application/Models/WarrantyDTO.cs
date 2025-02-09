using MoreMobile.Domain.Entities;
using MoreMobile.Resources.Core;
using System.ComponentModel.DataAnnotations;

namespace MoreMobile.Application.Models
{
    public class WarrantyDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceName = "CarModelRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public string CarModel { get; set; } = null!;

        [Required(ErrorMessageResourceName = "RegistrationNumberRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public string RegistrationNumber { get; set; } = null!;

        [Required(ErrorMessageResourceName = "VINRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public string VIN { get; set; } = null!;

        [Required(ErrorMessageResourceName = "ServiceTypeIdRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public Guid ServiceTypeId { get; set; }

        [Required(ErrorMessageResourceName = "ServiceDateRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public DateOnly ServiceDate { get; set; }

        public IEnumerable<VisitDateDTO> VisitDates { get; set; } = [];

        [Required(ErrorMessageResourceName = "UserIdRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public Guid? UserId { get; set; }

        public bool LostWarranty { get; set; }
        public string? LossWarrantyReason { get; set; }
    }
}