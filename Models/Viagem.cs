namespace turismoTCC.Models
{
    public class Viagem
    {
        public int IdViagem { get; set; }


        public int idRota { get; set; }
        public Rota? Rota { get; set; }


        public int idLocal { get; set; }
        public Localidade? Localidade { get; set; }



        public ICollection<Usuario>? Usuarios { get; set; }
    }
}
