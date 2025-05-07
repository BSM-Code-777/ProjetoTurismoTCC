using System.ComponentModel.DataAnnotations;

namespace turismoTCC.Models
{
    public class Localidade
    {
        [Key]
        [Required]
        [Display(Name = "Identificação da Localidade")]
        public int idLocal { get; set; }

        [Required]
        [StringLength(20)]
        public string? nome { get; set; }

        [Required]
        [StringLength(30)]
        public string? descricao { get; set; }

        [Required]
        [StringLength(20)]
        public string? tipo { get; set; }


        [Display(Name = "Identificação da posição")]
        public int idPosicao { get; set; }
        public Posicao? Posicao { get; set; }





    }
}
