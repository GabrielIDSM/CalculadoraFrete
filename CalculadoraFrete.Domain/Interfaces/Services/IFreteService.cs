using CalculadoraFrete.Domain.Entities;

namespace CalculadoraFrete.Domain.Interfaces.Services
{
    public interface IFreteService
    {
        Resposta ObterCotacoes(ParametroEnvio? parametroEnvio);
    }
}
