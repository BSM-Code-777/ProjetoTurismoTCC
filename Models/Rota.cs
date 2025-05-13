using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace turismoTCC.Models
{
    public class Rota
    {
        [Key]
        [Display(Name = "ID Rota")]
        public int IdRota { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string? nome { get; set; }

        
        [Display(Name = "ID Usuario")]
        [ForeignKey("Usuario")]
        public string? idUsuario { get; set; }
        public Usuario? Usuario { get; set; }

       
        [Display(Name = "ID Viagem")]
        [ForeignKey("Viagem")]
        public int idViagem { get; set; }
        public Viagem? Viagem { get; set; }



        public ICollection<Viagem>? Viagens { get; set; }
    }
}
