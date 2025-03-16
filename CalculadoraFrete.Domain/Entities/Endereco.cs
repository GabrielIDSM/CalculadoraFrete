namespace CalculadoraFrete.Domain.Entities
{
    public class Endereco
    {
        public string CEP { get; set; } = null!;
        public string UF { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Localidade { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Logradouro { get; set; } = null!;
    }
}
