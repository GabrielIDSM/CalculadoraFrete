using CalculadoraFrete.Domain.Entities;

namespace CalculadoraFrete.Domain.Interfaces.Integrations
{
    public interface IEnderecoIntegrationService
    {
        Endereco ObterEnderecoPorCEP(string cep);
    }
}
