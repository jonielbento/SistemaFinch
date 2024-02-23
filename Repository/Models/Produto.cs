using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFinch.Repository.Models
{
    public class Produto
    {
        public Produto()
        {
        }

        [Key] public int Id { get; set; }
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }

    }
}
