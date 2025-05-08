using System.ComponentModel.DataAnnotations;

namespace turismoTCC.Models
{
    public class Sugestoes
    {
        [Key]
        public int idSugestoes { get; set; }

        [Required]
        public string? nome { get; set; }

        [Required]
        public string? descricao { get; set; }


        public int idUsuario { get; set; }

        public Usuario? usuario { get; set; }
    }
}
