using Microsoft.EntityFrameworkCore;
using MotoManager.Domain.Entities.Commom;

namespace MotoManager.Domain.Entities
{
    [Index(nameof(Ein), IsUnique = true)]
    [Index(nameof(DriverLicense), IsUnique = true)]
    [Index(nameof(Identifier), IsUnique = true)]
    public class Driver : BaseEntity
    {
        public required string Name { get; set; }
        public required string Ein { get; set; }
        public required string DriverLicense { get; set; }
        public required string DriverLicenseType { get; set; }
        public required DateTime BornDate { get; set; }
        public string? DocumentID { get; set; }
        public required string Identifier { get; set; }
    }
}
