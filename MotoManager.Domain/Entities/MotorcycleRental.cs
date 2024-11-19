using MotoManager.Domain.Entities.Commom;

namespace MotoManager.Domain.Entities
{
    public class MotorcycleRental : BaseEntity
    {
        public Guid MotorcycleId { get; set; }
        public Motorcycle Motorcycle { get; set; } = null!;
        public Guid RentalPlanId { get; set; }
        public RentalPlans RentalPlans { get; set; } = null!;
        public Guid DriverId { get; set; }
        public Driver Driver { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
