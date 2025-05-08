using System.ComponentModel.DataAnnotations;
namespace turismoTCC.Models
{
    public class Beneficio
    {
        [Key]
        public int idBeneficio { get; set; }

        [Display(Name = "Desconto")]
        public float desconto { get; set; }

        [Required]
        [Display(Name = "Tipo de Benefício")]
        [StringLength(20)]
        public string? tipo { get; set; }

        public ICollection<Relacao>? Relacao { get; set; }
    }
}
