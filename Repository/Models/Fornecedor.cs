using System.ComponentModel.DataAnnotations;

namespace SistemaFinch.Repository.Models
{
    public class Fornecedor
    {
        public Fornecedor()
        {
        }

        [Key]public int Id { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public string CNPJ { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public bool Ativo { get; set; }
        public string CreateDate { get; set; }
        public string? UpdateDate { get; set; }

    }
}
