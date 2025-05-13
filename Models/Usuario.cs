using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace turismoTCC.Models
{
    public class Usuario : IdentityUser
    {

        [Required]
        [StringLength(50)]
        public string? nome { get; set; }



        public ICollection<Sugestao>? Sugestoes { get; set; }
        public ICollection<Registro>? Registros { get; set; }

    }
}
