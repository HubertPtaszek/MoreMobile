using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;
using MoreMobile.Resources.Core;

namespace MoreMobile.Application.Models
{
    public class ServiceTypeDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public string? Name { get; set; }

        [Required(ErrorMessageResourceName = "WarrantyLengthInMonthsRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public int WarrantyLengthInMonths { get; set; }

        [Required(ErrorMessageResourceName = "GrossPriceRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public decimal GrossPrice { get; set; }

        [Required(ErrorMessageResourceName = "NetPriceRequired", ErrorMessageResourceType = typeof(CoreResource))]
        public decimal NetPrice { get; set; }

        [Required(ErrorMessageResourceName = "VATRateRequired", ErrorMessageResourceType = typeof(CoreResource))]
        [Range(0, 100)]
        public decimal VATRate { get; set; }
    }
}