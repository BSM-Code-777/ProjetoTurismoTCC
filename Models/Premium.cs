using System.ComponentModel.DataAnnotations;

namespace turismoTCC.Models
{
    public class Premium
    {
        [Key]
        [Display(Name = "ID Premium")]
        public int idPremium { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Nome do Plano")]
        public string? nome { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Tempo de Inscrição")]
        public string? periodo { get; set; }

        [Required]
        [Display(Name = "Valor")]
        public float valor { get; set; }

        public ICollection<Registro>? Registros { get; set; }
        public ICollection<Parceria>? Parcerias { get; set; }
        public ICollection<Relacao>? Relacaos { get; set; }
    }
}
