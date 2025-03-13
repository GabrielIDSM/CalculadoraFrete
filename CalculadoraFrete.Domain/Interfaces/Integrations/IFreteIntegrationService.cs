using CalculadoraFrete.Domain.Entities;

namespace CalculadoraFrete.Domain.Interfaces.Integrations
{
    public interface IFreteIntegrationService
    {
        List<CotacaoFrete> ObterCotacoesFrete(ParametroEnvio parametroEnvio);
    }
}
