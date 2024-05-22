﻿using System.ComponentModel.DataAnnotations;

namespace MoreMobile.Domain.Entities
{
    public class ServiceType
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int WarrantyLengthInMonths { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal NetPrice { get; set; }

        [Range(0, 100)]
        public decimal VATRate { get; set; }
    }
}