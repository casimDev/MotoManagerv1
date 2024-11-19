using MotoManager.Domain.Entities.Commom;

namespace MotoManager.Domain.Entities
{
    public class RentalPlans : BaseEntity
    {
        public int Days { get; set; }
        public double Value { get; set; }
    }
}
