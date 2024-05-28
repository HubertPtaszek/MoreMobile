namespace MoreMobile.Domain.Entities
{
    public class VisitDate
    {
        public Guid Id { get; set; }
        public Guid WarrantyId { get; set; }
        public virtual Warranty Warranty { get; set; } = null!;
        public DateOnly InspectionDate { get; set; }
        public bool InspectionDone { get; set; }
        public bool FirstVisit { get; set; }
    }
}