using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace turismoTCC.Models
{
    public class Relacao
    {
        [Key]
        [Display(Name = "ID Relacao")]
        public int idRelacao { get; set; }

        [ForeignKey("Premium")]
        public int idPremium { get; set; }
        public Premium? Premium { get; set; }

        [ForeignKey("Beneficio")]
        public int idBeneficio { get; set; }
        public Beneficio? Beneficio { get; set; }
    }
}
