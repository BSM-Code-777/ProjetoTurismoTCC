namespace turismoTCC.Models
{
    public class Relacoes
    {
        public int idRelacoes { get; set; }

        public int idPremium { get; set; }
        public Premium? Premium { get; set; }

        public int idBeneficio { get; set; }
        public Beneficios? Beneficios { get; set;}
    }
}
