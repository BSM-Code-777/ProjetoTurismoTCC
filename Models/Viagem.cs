
using System.ComponentModel.DataAnnotations;


namespace turismoTCC.Models
{
    public class Viagem
    {
        [Key]

        [Display(Name = "ID Viagem")]
        public int IdViagem { get; set; }

      
        [Display(Name = "ID Rota")]
        public int idRota { get; set; }
        public Rota? Rota { get; set; }

       
        [Display(Name = "ID Local")]
        public int idLocal { get; set; }
        public Localidade? Localidade { get; set; }

    }
}
