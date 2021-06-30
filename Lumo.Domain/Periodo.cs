namespace Lumo.Domain
{
    public class Periodo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Orgao orgao { get; set; }
        public string Representacao { get; set; }
    }
}
