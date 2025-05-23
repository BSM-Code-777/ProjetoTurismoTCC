﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace turismoTCC.Models
{
    public class Sugestao
    {
        [Key]
        [Display(Name = "ID Sugestões")]
        public int idSugestoes { get; set; }

        [Required]
        [Display(Name = "Local")]
        public string? nome { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string? descricao { get; set; }

        [ForeignKey("Usuario")]
        public string? idUsuario { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
