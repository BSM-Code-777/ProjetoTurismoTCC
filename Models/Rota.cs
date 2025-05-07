using System.ComponentModel.DataAnnotations;

namespace turismoTCC.Models
{
    public class Rota
    {
        [Key]
        [Display(Name = "Identificação da rota")]
        public int IdRota { get; set; }

        [Required]
        [StringLength(50)]
        public string? nome { get; set; }

        [Required]
        [Display(Name = "Identificação do usuario")]
        public int idUsuario { get; set; }
        public Usuario? Usuario { get; set; }

        [Required]
        [Display(Name = "Identificação da viagem")]
        public int idViagem { get; set; }
        public Viagem? Viagem { get; set; }



        public ICollection<Localidade>? Localidades { get; set; }
    }
}
