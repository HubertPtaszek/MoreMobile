using MoreMobile.Domain.Entities;
using MoreMobile.Resources.Core;
using System.ComponentModel.DataAnnotations;

namespace MoreMobile.Application.Models
{
    public class VisitDateDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceName = "InspectionDateRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public DateTime InspectionDate { get; set; }

        public bool FirstVisit { get; set; }
        public bool InspectionDone { get; set; }
        public Guid WarrantyId { get; set; }
    }
}