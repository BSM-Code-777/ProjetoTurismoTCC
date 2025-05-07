using System.ComponentModel.DataAnnotations;

namespace turismoTCC.Models
{
    public class Premium
    {
        [Key]
        [Display(Name = "Identificação do Plano Premium")]
        public int IdPremium { get; set; }

        [Required]
        [StringLength(20)]
        public string? nome { get; set; }

        [Required]
        [StringLength(20)]
        public string? periodo { get; set; }

        [Required]
        public float valor { get; set; }

       

    }
}
