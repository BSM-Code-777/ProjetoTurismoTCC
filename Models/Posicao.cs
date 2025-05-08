using System.ComponentModel.DataAnnotations;

namespace turismoTCC.Models
{
    public class Posicao
    {
        [Key]
        [Display(Name = "ID Posição")]
        public int idPosicao { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public int latitude { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public int longitude { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        public string? bairro { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public string? endereco { get; set; }

        [Required]
        [Display(Name = "Rua")]
        public string? rua { get; set; }




    }
}
