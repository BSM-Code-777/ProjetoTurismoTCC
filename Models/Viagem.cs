using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace turismoTCC.Models
{
    public class Viagem
    {
        [Key]
        [Display(Name = "ID Viagem")]
        public int IdViagem { get; set; }

        [ForeignKey("Rota")]
        [Display(Name = "ID Rota")]
        public int idRota { get; set; }
        public Rota? Rota { get; set; }

        [ForeignKey("Localidade")]
        [Display(Name = "ID Local")]
        public int idLocal { get; set; }
        public Localidade? Localidade { get; set; }

    }
}
