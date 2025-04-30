using System.ComponentModel.DataAnnotations;

namespace turismoTCC.Models
{
    public class Registro
    {
        public int idRegistro { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Data do Inicio")]
        public DateTime dataInicio { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Data do Fim")]
        public DateTime dataFim { get; set; }


        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }


        public int idPremium { get; set; }
        public Premium? Premium { get; set; }
    }
}
