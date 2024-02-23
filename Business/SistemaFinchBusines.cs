using SistemaFinch.Commons;
using SistemaFinch.DataAccess;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace SistemaFinch.Business
{
    public partial class SistemaFinchBusines(string conn)
    {
        private readonly SqlDataAccess _dataAccess = new(conn);
        private readonly ApiDataAccess _apiDataAccess = new();

        public Resultado GetUsuario(string usuario, string senha)
        {
            if (string.IsNullOrWhiteSpace(usuario)) { return new(false, null); }
            if (string.IsNullOrWhiteSpace(senha)) { return new(false, null); }
            return _dataAccess.GetUsuario(usuario, senha);

        }

        public (Resultado, List<FornecedorDb>?) GetFornecedor(string nome = null)
        {
            var resultado = _dataAccess.GetFornecedor(nome);
            if (resultado.Success && !string.IsNullOrWhiteSpace(resultado.Message))
            {
                return JsonSerializer.Deserialize<List<FornecedorDb>>(resultado.Message);
            }
            return (null, null);

        }

        public (Resultado, List<ProdutoDb>?) GetProduto(string? nome = null)
        {
            var resultado = _dataAccess.GetProduto(nome);
            if (resultado.Success && !string.IsNullOrWhiteSpace(resultado.Message))
            {
                return JsonSerializer.Deserialize<List<ProdutoDb>>(resultado.Message);
            }
            return null;

        }

        public Resultado PostFornecedor(string cnpj, string nome, string cep, string estado, string bairro, string cidade, string complemento, string numero, string rua, bool ativo)
        {
            if (string.IsNullOrWhiteSpace(nome)) { return new(false, "o nome não pode ser nulo"); }
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8 || !int.TryParse(cep, out _)) { return new(false, "CEP inválido"); }
            if (string.IsNullOrWhiteSpace(estado)) { return new(false, ""); }
            if (string.IsNullOrWhiteSpace(bairro)) { return new(false, ""); }
            if (string.IsNullOrWhiteSpace(cidade)) { return new(false, ""); }
            if (string.IsNullOrWhiteSpace(complemento)) { return new(false, ""); }
            if (string.IsNullOrWhiteSpace(numero)) { return new(false, ""); }
            if (string.IsNullOrWhiteSpace(rua)) { return new(false, ""); }

            if (!ValidarCnpj(cnpj))
            {
                return new(false, "Cnpj invalido");
            }

            var resultado = _dataAccess.PostFornecedor(cnpj, nome, cep, estado, bairro, cidade, complemento, numero, rua, ativo);
            if (!resultado)
            {
                return new(true, "Operação falhou");
            }
            return new(true, "Operação executada com sucesso"); ;
        }

        public Resultado PostProduto(int fornecedorId, string nome, string quantidade)
        {
            if (fornecedorId <= 0) { return false; }
            if (string.IsNullOrWhiteSpace(nome)) { return false; }
            if (!int.TryParse(quantidade, out var intQuantidade)) { return false; }

            var resultado = _dataAccess.PostProduto(fornecedorId, nome, intQuantidade);

            return resultado;
        }


        public Resultado UpdateFornecedor(int id, string nome, string cep, string estado, string bairro, string cidade, string complemento, string numero, string rua, bool ativo)
        {
            if (id <= 0) { return false; }
            if (string.IsNullOrWhiteSpace(nome)) { return false; }
            if (string.IsNullOrWhiteSpace(cep)) { return false; }
            if (string.IsNullOrWhiteSpace(estado)) { return false; }
            if (string.IsNullOrWhiteSpace(bairro)) { return false; }
            if (string.IsNullOrWhiteSpace(cidade)) { return false; }
            if (string.IsNullOrWhiteSpace(complemento)) { return false; }
            if (string.IsNullOrWhiteSpace(numero)) { return false; }
            if (string.IsNullOrWhiteSpace(rua)) { return false; }

            var resultado = _dataAccess.UpdateFornecedor(id, nome, cep, estado, bairro, cidade, complemento, numero, rua, ativo);

            return resultado;
        }

        public Resultado UpdateProduto(int id, int fornecedorid, string nome, string quantidade)
        {
            if (id <= 0) { return false; }
            if (fornecedorid <= 0) { return false; }
            if (string.IsNullOrWhiteSpace(nome)) { return false; }
            if (!int.TryParse(quantidade, out var intQuantidade)) { return false; }

            var resultado = _dataAccess.UpdateProduto(id, fornecedorid, nome, intQuantidade);

            return resultado;
        }

        public Resultado DeleteFornecedor(string id)
        {
            if (!int.TryParse(id, out int identify)) { return false; }

            var resultado = _dataAccess.DeleteFornecedor(identify);

            return resultado;
        }

        public Resultado DeleteProduto(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (int.TryParse(id, out int produtoId))
                {
                    return _dataAccess.DeleteProduto(produtoId);
                }
            }

            return false;

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
