using System.ComponentModel.DataAnnotations;

namespace MotoManager.Dtos
{
    public class CreateMotoDto
    {
        [Required]
        public string Identificador { get; set; } = string.Empty;
        [Required]
        public string Modelo { get; set; } = string.Empty;
        [Required]
        public string Placa { get; set; } = string.Empty;
        [Required]
        public int Ano { get; set; }

    }
}
