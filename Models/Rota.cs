namespace turismoTCC.Models
{
    public class Rota
    {
        public int IdRota { get; set; }

        public string? nome { get; set;}


        public int usuario { get; set; }
        public Usuario? Usuario { get; set; }


        public int idViagem { get; set; }
        public Viagem? Viagem { get; set;}



        public ICollection<Localidade>? Localidades { get; set; }
    }
}
