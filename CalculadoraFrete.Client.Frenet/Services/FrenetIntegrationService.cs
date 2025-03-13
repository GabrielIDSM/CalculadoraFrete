using System.Text;
using CalculadoraFrete.Domain.Entities;
using CalculadoraFrete.Domain.Interfaces.Integrations;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace CalculadoraFrete.Client.Frenet.Services
{
    public class FrenetIntegrationService(IConfiguration configuration) : IFreteIntegrationService
    {
        private readonly string _shippingUrl = configuration["Frenet:ShippingURL"]!;
        private readonly string _token = Environment.GetEnvironmentVariable("FRENET_TOKEN")!;

        public List<CotacaoFrete> ObterCotacoesFrete(ParametroEnvio parametroEnvio)
        {
            List<CotacaoFrete> cotacoes = [];
            var body = new
            {
                SellerCEP = parametroEnvio.CEPOrigem,
                RecipientCEP = parametroEnvio.CEPDestino,
                ShipmentInvoiceValue = parametroEnvio.ValorDeclarado,
                ShippingItemArray = new List<dynamic>() {
                    new {
                        Quantity = 1,
                        Height = parametroEnvio.Altura,
                        Length = parametroEnvio.Comprimento,
                        Weight =  parametroEnvio.Peso,
                        Width = parametroEnvio.Largura
                    }
                },
                RecipientCountry = "BR"
            };
            string bodyAsString = System.Text.Json.JsonSerializer.Serialize(body);
            StringContent bodyAsStringContent = new(bodyAsString, Encoding.UTF8, "application/json");

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("token", _token);

                HttpResponseMessage response = client.PostAsync(_shippingUrl, bodyAsStringContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    using JsonDocument responseAsJsonDocument = JsonDocument.Parse(responseBody);
                    JsonElement responseAsJson = responseAsJsonDocument.RootElement;
                    foreach (JsonElement cotacao in responseAsJson.GetProperty("ShippingSevicesArray").EnumerateArray())
                    {
                        bool isErro = cotacao.GetProperty("Error").GetBoolean();

                        if (!isErro)
                        {
                            cotacoes.Add(new CotacaoFrete
                            {
                                Transportadora = cotacao.GetProperty("Carrier").GetString()!,
                                CodigoTransportadora = cotacao.GetProperty("CarrierCode").GetString()!,
                                Servico = cotacao.GetProperty("ServiceDescription").GetString()!,
                                CodigoServico = cotacao.GetProperty("ServiceCode").GetString()!,
                                PrazoEntrega = Convert.ToInt32(cotacao.GetProperty("DeliveryTime").GetString()),
                                Preco = Convert.ToDouble(cotacao.GetProperty("ShippingPrice").GetString())
                            });
                        }
                    }
                }
                else
                {
                    throw new Exception($"Erro interno");
                }
            }

            return cotacoes;
        }
    }
}
