namespace turismoTCC.Models
{
    public class Localidade
    {
        public int idLocal { get; set; }
        public string? nome { get; set; }
        public string? descricao { get; set; }
        public string? tipo { get; set; }



        public int idPosicao { get; set; }
        public Posicao? Posicao { get; set; }





    }
}
