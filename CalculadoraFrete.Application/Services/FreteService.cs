using CalculadoraFrete.Domain.Entities;
using CalculadoraFrete.Domain.Interfaces.Integrations;
using CalculadoraFrete.Domain.Interfaces.Services;
using Microsoft.Extensions.Caching.Memory;

namespace CalculadoraFrete.Application.Services
{
    public class FreteService(IMemoryCache cache,
        IEnderecoIntegrationService enderecoIntegrationService,
        IFreteIntegrationService freteIntegrationService) : IFreteService
    {
        private readonly IMemoryCache _cache = cache;
        private readonly IEnderecoIntegrationService _enderecoIntegrationService = enderecoIntegrationService;
        private readonly IFreteIntegrationService _freteIntegrationService = freteIntegrationService;

        public Resposta ObterCotacoes(ParametroEnvio? parametroEnvio)
        {
            try
            {
                ValidarParametroEnvio(parametroEnvio);

                string cacheChave = string.Join("_",
                    "frete",
                    parametroEnvio!.CEPOrigem,
                    parametroEnvio!.CEPDestino,
                    parametroEnvio!.Peso,
                    parametroEnvio!.Largura,
                    parametroEnvio!.Altura,
                    parametroEnvio!.Comprimento,
                    parametroEnvio!.ValorDeclarado
                );

                if (_cache.TryGetValue(cacheChave, out Resposta? cacheResposta))
                {
                    return cacheResposta!;
                }

                List<CotacaoFrete> cotacoes = _freteIntegrationService.ObterCotacoesFrete(parametroEnvio!);
                Endereco origem = _enderecoIntegrationService.ObterEnderecoPorCEP(parametroEnvio!.CEPOrigem);
                Endereco destino = _enderecoIntegrationService.ObterEnderecoPorCEP(parametroEnvio!.CEPDestino);
                Resposta resposta = new()
                {
                    Sucesso = true,
                    ParametroEnvio = parametroEnvio,
                    Origem = origem,
                    Destino = destino,
                    Cotacoes = cotacoes
                };

                _cache.Set(cacheChave, resposta, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));

                return resposta;
            }
            catch (Exception e)
            {
                return new Resposta()
                {
                    Sucesso = false,
                    MensagemErro = e.Message
                };
            }

        }

        private void ValidarParametroEnvio(ParametroEnvio? parametroEnvio)
        {
            ArgumentNullException.ThrowIfNull(parametroEnvio);

            if (string.IsNullOrWhiteSpace(parametroEnvio.CEPOrigem))
                throw new Exception("O valor do campo \"CEP de origem\" não pode ser nulo ou vazio");

            if (string.IsNullOrWhiteSpace(parametroEnvio.CEPDestino))
                throw new Exception("O valor do campo \"CEP de destino\" não pode ser nulo ou vazio");

            if (parametroEnvio.Peso <= 0)
                throw new Exception("O valor do campo \"Peso do produto\" deve ser maior que 0.0 kg");

            if (parametroEnvio.ValorDeclarado <= 0)
                throw new Exception("O valor do campo \"Valor declarado\" deve ser maior que R$ 0,00");

            if (parametroEnvio.Largura <= 0)
                throw new Exception("O valor do campo \"Largura\" deve ser maior que 0 cm");

            if (parametroEnvio.Altura <= 0)
                throw new Exception("O valor do campo \"Altura\" deve ser maior que 0 cm");

            if (parametroEnvio.Comprimento <= 0)
                throw new Exception("O valor do campo \"Comprimento\" deve ser maior que 0 cm");
        }
    }
}
