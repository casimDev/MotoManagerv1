using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MotoManager.Domain.Entities
{
    public class Motorcycle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public required string Identificador { get; set; }
        public required string Model { get; set; }
        public required string Plate { get; set; }
        public required int Year { get; set; }
    }
}
