using System.ComponentModel.DataAnnotations;

namespace MotoManager.Dtos
{
    public class CreateDriverDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Identificador { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string Numero_Cnh { get; set; }
        [Required]
        public string Tipo_Cnh { get; set; }
        [Required]
        public DateTime Data_Nascimento { get; set; }
        public string? Imagem_Cnh { get; set; }
    }
}
