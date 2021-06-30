namespace Lumo.Domain
{
    public class Orgao
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string EstadoResp { get; set; }
        public string MunicipioResp { get; set; }
    }
}
