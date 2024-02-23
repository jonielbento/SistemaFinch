using SistemaFinch.Commons;
using SistemaFinch.DataAccess;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;

namespace SistemaFinch.Business
{
    public partial class SistemaFinchBusines(string conn)
    {
        private readonly SqlDataAccess _dataAccess = new(conn);
        private readonly ApiDataAccess _apiDataAccess = new();

        public Resultado GetUsuario(string usuario, string senha)
        {
            if (string.IsNullOrWhiteSpace(usuario)) { return new(false, "Usuario ou senha incorreta"); }
            if (string.IsNullOrWhiteSpace(senha)) { return new(false, "Usuario ou senha incorreta"); }
            var (resultado, nome) = _dataAccess.GetUsuario(usuario, senha);
            return new(resultado, nome);
        }

        public (Resultado, List<FornecedorDb>?) GetFornecedor(string nome = null)
        {
            var resultado = _dataAccess.GetFornecedor(nome);
            if (resultado.Success && !string.IsNullOrWhiteSpace(resultado.Message))
            {

                return (new(true, null), JsonSerializer.Deserialize<List<FornecedorDb>>(resultado.Message));
            }
            return (new(false, "Não foi possivel consultar fornecedor"), null);

        }

        public (Resultado, List<ProdutoDb>?) GetProduto(string? nome = null)
        {
            var resultado = _dataAccess.GetProduto(nome);
            if (resultado.Success && !string.IsNullOrWhiteSpace(resultado.Message))
            {
                return (new(true, null), JsonSerializer.Deserialize<List<ProdutoDb>>(resultado.Message));
            }
            return (new(false, "Não foi possivel consultar Produto"), null);

        }

        public Resultado PostFornecedor(string cnpj, string nome, string cep, string estado, string bairro, string cidade, string complemento, string numero, string rua, bool ativo)
        {
            if (!ValidarCnpj(cnpj))
            {
                return new(false, "Cnpj invalido");
            }

            var resultado = _dataAccess.PostFornecedor(cnpj, nome, cep, estado, bairro, cidade, complemento, numero, rua, ativo);
            if (!resultado)
            {
                return new(true, "Operação falhou");
            }
            return new(true, "Operação executada com sucesso"); 
        }

        public Resultado PostProduto(int fornecedorId, string nome, string quantidade)
        {
            if (fornecedorId <= 0) { return new(false, "selecione um fornecedor"); }
            if (string.IsNullOrWhiteSpace(nome)) { return new(false, "Nome não pode ser nulo"); }
            if (!int.TryParse(quantidade, out var intQuantidade)) { return new(false, "Informe uma quantidade"); }


            var resultado = _dataAccess.PostProduto(fornecedorId, nome, intQuantidade);

            return new(resultado, "Operação executada com sucesso");
        }


        public Resultado UpdateFornecedor(int id, string nome, string cep, string estado, string bairro, string cidade, string complemento, string numero, string rua, bool ativo)
        {
            if (id <= 0) { return new(false, "Fornecedor inexiste"); }
            
            var resultado = _dataAccess.UpdateFornecedor(id, nome, cep, estado, bairro, cidade, complemento, numero, rua, ativo);

            return new(resultado, "Fornecedor atualizado com sucesso");
        }

        public Resultado UpdateProduto(int id, int fornecedorid, string nome, string quantidade)
        {
            if (id <= 0) { return new(false, "Produto inexiste"); }
            if (fornecedorid <= 0) { return new(false, "Fornecedor inexiste"); }
            if (string.IsNullOrWhiteSpace(nome)) { return new(false, "Não pode ser vazio"); }
            if (!int.TryParse(quantidade, out var intQuantidade)) { return new(false, "Informe a quantidade"); }

            var resultado = _dataAccess.UpdateProduto(id, fornecedorid, nome, intQuantidade);

            return new(resultado, "Update com sucesso");
        }
    

        public Resultado DeleteFornecedor(string id)
        {
            if (!int.TryParse(id, out int identify)) { return new(false, "Sem fornecedor"); }

            var resultado = _dataAccess.DeleteFornecedor(identify);

            return new(resultado, "Deletado com sucesso");
        }

        public Resultado DeleteProduto(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (int.TryParse(id, out int produtoId))
                {
                    return new(_dataAccess.DeleteProduto(produtoId), "Deletado com sucesso");
                }
            }

            return new(false, "Sem produto");

        }

        public async Task<Cep> GetCepAsync(string cep)
        {
            var resultado = await _apiDataAccess.GetCepAsync(cep);
            return JsonSerializer.Deserialize<Cep>(resultado.Message);
        }

        private static bool ValidarCnpj(string cnpj)
        {
            string cnpjLimpo = MyRegex().Replace(cnpj, "");

            if (cnpjLimpo.Length != 14)
            {
                return false;
            }

            int[] multiplicadoresPrimeiroDigito = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplicadoresSegundoDigito = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

            int primeiroDigitoVerificador = CalcularDigitoVerificador(cnpjLimpo, multiplicadoresPrimeiroDigito);
            int segundoDigitoVerificador = CalcularDigitoVerificador(cnpjLimpo, multiplicadoresSegundoDigito);

            return cnpjLimpo.EndsWith($"{primeiroDigitoVerificador}{segundoDigitoVerificador}");
        }

        static int CalcularDigitoVerificador(string cnpj, int[] multiplicadores)
        {
            int soma = 0;
            for (int i = 0; i < multiplicadores.Length; i++)
            {
                soma += int.Parse(cnpj[i].ToString()) * multiplicadores[i];
            }

            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        [GeneratedRegex(@"[^\d]")]
        private static partial Regex MyRegex();
    }
}
