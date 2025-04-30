namespace turismoTCC.Models
{
    public class Parceria
    {
        public int idParceria { get; set; }

        public string? beneficio { get; set; }

        public int idLocal { get; set;}
        public Localidade? Localidade { get; set; }

        public int idPremium { get; set; }
        public Premium? Premium { get; set; }
    }
}
