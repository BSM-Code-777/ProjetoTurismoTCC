using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace turismoTCC.Models
{
    public class Parceria
    {
        [Key]
        [Display(Name = "ID Parceria")]
        public int idParceria { get; set; }

        [Required]
        [Display(Name = "Benefício")]
        public string? beneficio { get; set; }

        [ForeignKey("Localidade")]
        [Display(Name = "ID Local")]
        public int idLocal { get; set; }
        public Localidade? Localidade { get; set; }

        [ForeignKey("Premium")]
        [Display(Name = "ID Premium")]

        public int idPremium { get; set; }
        public Premium? Premium { get; set; }
    }
}
