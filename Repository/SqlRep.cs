using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SistemaFinch.Commons;
using SistemaFinch.Repository.Models;
using System.Data;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace SistemaFinch.Repository
{
    public class SqlRep(string conn)
    {
        private readonly ContextDb _context = new(conn);
        private readonly SqlConnection _connection = new(conn);

        public bool DeleteFornecedor(int id)
        {
            var fornecedor = _context.Fornecedor.Find(id);
            if(fornecedor is not null)
            {
                fornecedor.Ativo = false;
                fornecedor.UpdateDate = DateTime.Now.ToString();
                int effectRows = _context.SaveChanges();

                return effectRows != 0;
            }

            return false;
        }

        public bool DeleteProduto(int id)
        {
            var produto = _context.Produto.Find(id);
            _context.Produto.Remove(produto);
            int effectRows = _context.SaveChanges();

            return effectRows != 0;

        }

        public bool UpdateFornecedor(int id, string nome, string cep, string estado, string bairro, string cidade, string complemento, string numero, string rua, bool ativo)
        {
            try
            {
                var fornecedor = _context.Fornecedor.Find(id);

                if (fornecedor is null) { return false; }

                fornecedor.Ativo = ativo;
                fornecedor.CEP = cep;
                fornecedor.Nome = nome;
                fornecedor.UpdateDate = DateTime.Now.ToString();
                fornecedor.Estado = estado;
                fornecedor.Bairro = bairro;
                fornecedor.Cidade = cidade;
                fornecedor.Complemento = complemento;
                fornecedor.Numero = numero;
                fornecedor.Rua = rua;

                int effectRows = _context.SaveChanges();

                return effectRows != 0;
            }
            catch (Exception e) { return false; }
        }


        public bool UpdateProduto(int id, int fornecedorid, string nome, int quantidade)
        {
            try
            {
                var produto = _context.Produto.Find(id);

                if (produto is null) { return false; }

                produto.Nome = nome;
                produto.Quantidade = quantidade;
                produto.UpdateDate = DateTime.Now.ToString();
                produto.FornecedorId = fornecedorid;

                int effectRows = _context.SaveChanges();

                return effectRows != 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CreateFornecedor(string cnpj, string nome, string cep, string estado, string bairro, string cidade, string complemento, string numero, string rua, bool ativo)
        {
            try
            {
                Fornecedor addFornecedor = new()
                {
                    Nome = nome,
                    CNPJ = cnpj,
                    CEP = cep,
                    Estado = estado,
                    Bairro = bairro,
                    Cidade = cidade,
                    Complemento = complemento,
                    Numero = numero,
                    Rua = rua,
                    Ativo = ativo,
                    CreateDate = DateTime.Now.ToString()
                };

                var fornecedor = _context.Fornecedor.Add(addFornecedor);

                int effectRows = _context.SaveChanges();

                //Resultado resultado = new(effectRows != 0, JsonSerializer.Serialize(fornecedor));

                return effectRows != 0;
            }
            catch (Exception e) { return false; }
        }

        public bool CreateProduto(int fornecedorId, string nome, int quantidade)
        {
            try
            {
                Produto addProduto = new();
                

                addProduto.Nome = nome;
                addProduto.Quantidade = quantidade;
                addProduto.CreateDate = DateTime.Now.ToString();
                addProduto.FornecedorId = fornecedorId;

                var produto = _context.Produto.Add(addProduto);

                int effectRows = _context.SaveChanges();

                return effectRows != 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public (bool, string?) Auth(string sql)
        {
            Reconnect();

            try
            {
                SqlCommand command = new(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) { while (reader.Read()) { return (true, reader["Usuario"].ToString()); } }
                return (false, null);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao consultar o banco de dados: {ex.Message}");
            }
        }

        public Resultado ConsultaFornecedor(string sql)
        {
            Reconnect();

            SqlCommand command = new(sql, _connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                JsonArray fornecedores = [];

                while (reader.Read())
                {
                    JsonObject fornecedor = [];

                    fornecedor.Add("Id", Convert.ToInt32(reader["Id"]));
                    fornecedor.Add("Nome", reader["Nome"].ToString());
                    fornecedor.Add("CNPJ", reader["CNPJ"].ToString());
                    fornecedor.Add("Endereco", reader["Endereco"].ToString());
                    fornecedor.Add("Ativo", Convert.ToBoolean(reader["Ativo"]));
                    fornecedor.Add("Rua", reader["Rua"].ToString());
                    fornecedor.Add("Numero", reader["Numero"].ToString());
                    fornecedor.Add("Bairro", reader["Bairro"].ToString());
                    fornecedor.Add("Complemento", reader["Complemento"].ToString());
                    fornecedor.Add("CEP", reader["CEP"].ToString());
                    fornecedor.Add("Cidade", reader["Cidade"].ToString());
                    fornecedor.Add("Estado", reader["Estado"].ToString());

                    fornecedores.Add(fornecedor);
                }
                return new(true, JsonSerializer.Serialize(fornecedores));
            }
            return new(false, null);
        }

        public Resultado ConsultaProduto(string sql)
        {
            Reconnect();

            SqlCommand command = new(sql, _connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                JsonArray fornecedores = [];

                while (reader.Read())
                {
                    JsonObject fornecedor = [];
                    fornecedor.Add("Id", Convert.ToInt32(reader["Id"]));
                    // fornecedor.Add("FornecedorId", reader["FornecedorId"].ToString());
                    fornecedor.Add("Nome", reader["Nome"].ToString());
                    fornecedor.Add("Fornecedor", reader["Fornecedor"].ToString());
                    fornecedor.Add("Quantidade", reader["Quantidade"].ToString());

                    fornecedores.Add(fornecedor);
                }
                return new(true, JsonSerializer.Serialize(fornecedores));
            }
            return new(false, null);
        }

        private void Reconnect()
        {
            try
            {
                _connection.Close();
                if (_connection.State == ConnectionState.Broken) { _connection.Close(); }
                if (_connection.State == ConnectionState.Closed) { _connection.Open(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao reconectar o banco de dados: {ex.Message}");
            }
        }


    }

}
