namespace MoreMobile.Domain.Entities
{
    public class VisitDate
    {
        public Guid Id { get; set; }
        public Guid WarrantyId { get; set; }
        public virtual Warranty Warranty { get; set; } = null!;
        public DateTime InspectionDate { get; set; }
        public bool InspectionDone { get; set; }
        public bool ReminderSent { get; set; }
        public bool FirstVisit { get; set; }
        public bool IsTimeToSendReminder => (DateOnly.FromDateTime(InspectionDate).DayNumber - DateOnly.FromDateTime(DateTime.Now).DayNumber) < 2;
    }
}