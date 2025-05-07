using System.ComponentModel.DataAnnotations;

namespace turismoTCC.Models
{
    public class Posicao
    {
        [Key]
        [Display(Name = "Identificação da posição")]
        public int idPosicao { get; set; }

        [Required]
        public int latitude { get; set; }

        [Required]
        public int longitude { get; set; }

        [Required]
        public string? bairro { get; set; }

        [Required]
        public string? endereco { get; set; }

        [Required]
        public string? rua { get; set; }




    }
}
