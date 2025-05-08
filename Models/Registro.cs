using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace turismoTCC.Models
{
    public class Registro
    {

        [Key]
        [Display(Name = "ID Registro")]
        public int idRegistro { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data do Inicio")]
        public DateTime dataInicio { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data do Fim")]
        public DateTime dataFim { get; set; }


        [ForeignKey("Usuario")]
        [Display(Name = "ID Usuário")]
        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }


        [ForeignKey("Premium")]
        [Display(Name = "ID Premium")]
        public int idPremium { get; set; }
        public Premium? Premium { get; set; }
    }
}
