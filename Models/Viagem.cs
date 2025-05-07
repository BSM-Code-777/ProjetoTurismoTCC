using System.ComponentModel.DataAnnotations;

namespace turismoTCC.Models
{
    public class Viagem
    {
        [Key]
        [Display(Name = "Identificação da Viagem")]
        public int IdViagem { get; set; }

        [Required]
        [Display(Name = "Identificação da rota")]
        public int idRota { get; set; }
        public Rota? Rota { get; set; }

        [Required]
        [Display(Name = "Identificação da localidade")]
        public int idLocal { get; set; }
        public Localidade? Localidade { get; set; }



        public ICollection<Usuario>? Usuarios { get; set; }
    }
}
