using System.ComponentModel.DataAnnotations;

namespace turismoTCC.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        [Display(Name = "Identificação do Usuario")]
        public int idUsuario { get; set; }

        [Required]
        [StringLength(20)]
        public string? nome { get; set; }

        [Required]
        [StringLength(50)]
        public string? email { get; set; }

        [Required]
        [StringLength(20)]
        public string? senha { get; set; }

     


        //public ICollection<Viagem>? Viagens { get; set; }

        //public ICollection<Sugestoes>? Sugestoes { get; set; }



    }
}
