namespace CalculadoraFrete.Domain.Entities
{
    public class Resposta
    {
        public ParametroEnvio? ParametroEnvio { get; set; }
        public List<CotacaoFrete>? Cotacoes { get; set; }
        public bool Sucesso { get; set; }
        public string? MensagemErro { get; set; }
    }
}
