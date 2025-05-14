
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace turismoTCC.Models
{
    public class Viagem
    {
        [Key]

        [Display(Name = "ID Viagem")]
        public int IdViagem { get; set; }

        [Required]
        [Display(Name = "Titulo")]
        public string? nome { get; set; }

        [ForeignKey("Localidade")]
        [Display(Name = "ID Local")]
        public int idLocal { get; set; }
        public Localidade? Localidade { get; set; }

        [ForeignKey("Usuario")]
        [Display(Name = "ID Usuario")]
        public string? idUsuario { get; set; }
        public Usuario? Usuario { get; set; }

    }
}
