using SistemaFinch.Commons;
using SistemaFinch.Repository;

namespace SistemaFinch.DataAccess
{
    public class SqlDataAccess(string conn)
    {
        private readonly SqlRep _sqlRep = new(conn);

        public (bool, string?) GetUsuario(string usuario, string senha)
        {
            string sql = $"select Usuario from login where Usuario = '{usuario}' and Senha = '{senha}'";

            return _sqlRep.Auth(sql);

        }

        public Resultado GetFornecedor(string? nome = null)
        {
            string sql = "select Id, Nome, CNPJ, concat('Rua: ', Rua, ', Nº ', Numero, ' Bairro: ', Bairro, ', Comp: ', Complemento, ', CEP: ', CEP, ' Cidade: ', Cidade, ', UF: ', Estado) as Endereco, Ativo, Rua, Numero, Bairro , Complemento, CEP, Cidade, Estado from fornecedor";

            if (!string.IsNullOrWhiteSpace(nome))
            {
                sql += $" where nome = '{nome}'";
            }

            return _sqlRep.ConsultaFornecedor(sql);

        }

        public Resultado GetProduto(string? nome = null)
        {
            string sql = "select p.Id, p.Nome, f.Nome as Fornecedor, p.Quantidade from produto p join Fornecedor f on p.FornecedorId = f.Id";

            if (!string.IsNullOrWhiteSpace(nome))
            {
                sql += $" where p.Nome = '{nome}'";
            }

            return _sqlRep.ConsultaProduto(sql);
        }

        public bool PostFornecedor(string cnpj, string nome, string cep, string estado, string bairro, string cidade, string complemento, string numero, string rua, bool ativo)
        => _sqlRep.CreateFornecedor(cnpj, nome, cep, estado, bairro, cidade, complemento, numero, rua, ativo);

        public bool PostProduto(int fornecedorId, string nome, int quantidade)
        => _sqlRep.CreateProduto(fornecedorId, nome, quantidade);

        public bool UpdateFornecedor(int id, string nome, string cep, string estado, string bairro, string cidade, string complemento, string numero, string rua, bool ativo)
        => _sqlRep.UpdateFornecedor(id, nome, cep, estado, bairro, cidade, complemento, numero, rua, ativo);
        public bool UpdateProduto(int id, int fornecedorid, string nome, int quantidade)
       => _sqlRep.UpdateProduto(id, fornecedorid, nome, quantidade);

        public bool DeleteFornecedor(int id)
        => _sqlRep.DeleteFornecedor(id);

        public bool DeleteProduto(int id)
        => _sqlRep.DeleteProduto(id);

    }
}
