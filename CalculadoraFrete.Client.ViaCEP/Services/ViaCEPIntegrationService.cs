using System.Text.Json;
using CalculadoraFrete.Domain.Entities;
using CalculadoraFrete.Domain.Interfaces.Integrations;
using Microsoft.Extensions.Configuration;

namespace CalculadoraFrete.Client.ViaCEP.Services
{
    public class ViaCEPIntegrationService(IConfiguration configuration) : IEnderecoIntegrationService
    {
        private readonly string _url = configuration["ViaCEP:URL"]!;

        public Endereco ObterEnderecoPorCEP(string cep)
        {
            using HttpClient client = new();
            HttpResponseMessage response = client.GetAsync(_url.Replace("{cep}", cep)).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                using JsonDocument responseAsJsonDocument = JsonDocument.Parse(responseBody);
                JsonElement responseAsJson = responseAsJsonDocument.RootElement;
                return new Endereco
                {
                    CEP = responseAsJson.GetProperty("cep").GetString()!,
                    UF = responseAsJson.GetProperty("uf").GetString()!,
                    Estado = responseAsJson.GetProperty("estado").GetString()!,
                    Localidade = responseAsJson.GetProperty("localidade").GetString()!,
                    Bairro = responseAsJson.GetProperty("bairro").GetString()!,
                    Logradouro = responseAsJson.GetProperty("logradouro").GetString()!
                };
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception("O CEP informado é inválido");
            }
            else
            {
                throw new Exception("Erro interno");
            }
        }
    }
}
