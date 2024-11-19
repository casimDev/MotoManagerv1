using MotoManager.Domain.Entities.Commom;

namespace MotoManager.Domain.Entities
{
    public class Deliveries : BaseEntity
    {
        public string Address { get; set; } = string.Empty;
    }
}
