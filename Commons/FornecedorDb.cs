namespace SistemaFinch.Commons
{
    public class FornecedorDb
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get => "Rua: " + Rua + " + Nº " + Numero + " Bairro: " + Bairro + " + Comp: " + Complemento + " + CEP: " + CEP + " Cidade: " + Cidade + " + UF: " + Estado; }
        public bool Ativo { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }
}
