using System.ComponentModel.DataAnnotations;

namespace turismoTCC.Models
{
    public class Registro
    {

        [Key]
        [Display(Name = "Identificação do registro")]
        public int idRegistro { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data do Inicio")]
        public DateTime dataInicio { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data do Fim")]
        public DateTime dataFim { get; set; }


        [Required]
        [Display(Name = "Identificação do usuario")]
        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }


        [Required]
        [Display(Name = "Identificação do Plano Premium")]
        public int idPremium { get; set; }
        public Premium? Premium { get; set; }
    }
}
