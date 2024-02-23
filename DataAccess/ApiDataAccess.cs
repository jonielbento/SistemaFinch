using SistemaFinch.Commons;
using SistemaFinch.Repository;

namespace SistemaFinch.DataAccess
{
    public class ApiDataAccess
    {
        private readonly ApiRep _apiRep = new();

        public async Task<Resultado> GetCepAsync(string cep)
        => await _apiRep.GetCepAsync($"https://viacep.com.br/ws/{cep}/json/");
    }
}
