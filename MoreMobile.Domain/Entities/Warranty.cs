namespace MoreMobile.Domain.Entities
{
    public class Warranty
    {
        public Guid Id { get; set; }
        public string CarModel { get; set; } = null!;
        public string RegistrationNumber { get; set; } = null!;
        public string VIN { get; set; } = null!;
        public bool LostWarranty { get; set; }
        public string? LossWarrantyReason { get; set; }
        public Guid ServiceTypeId { get; set; }
        public virtual ServiceType ServiceType { get; set; } = null!;
        public DateOnly ServiceDate { get; set; }
        public virtual ICollection<VisitDate> VisitDates { get; set; } = [];
        public Guid? UserId { get; set; }
        public virtual User? User { get; set; } = null!;
        public Guid? CompanyId { get; set; }
        public virtual Company? Company { get; set; } = null!;
    }
}