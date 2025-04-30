namespace turismoTCC.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        public string? nome { get; set; }

        public string? email { get; set; }

        public string? senha { get; set; }


        public ICollection<Viagem>? Viagens { get; set; }

       

    }
}
