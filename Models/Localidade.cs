using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace turismoTCC.Models
{
    public class Localidade
    {
        [Key]
        [Display(Name = "ID Local")]
        public int idLocal { get; set; }

        [Required]
        [StringLength(30)]
        public string? nome { get; set; }

        [Required]
        [StringLength(100)]
        public string? linkMaps { get; set; }

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

        [Required]
        [StringLength(100)]
        [Display(Name = "Descrição")]
        public string? descricao { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Tipo de Local")]
        public string? tipo { get; set; }


        public ICollection<Viagem>? Viagens { get; set; }



    }
}
