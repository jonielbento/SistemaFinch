using SistemaFinch.Commons;

namespace SistemaFinch.Repository
{
    public class ApiRep
    {
        private readonly HttpClient _httpClient = new();

        public async Task<Resultado> GetCepAsync(string url)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync(url);
            string conteudo = await resposta.Content.ReadAsStringAsync();

            return new(true, conteudo);
        }

    }
}
