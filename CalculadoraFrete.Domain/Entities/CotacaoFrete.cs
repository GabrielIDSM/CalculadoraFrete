namespace CalculadoraFrete.Domain.Entities
{
    public class CotacaoFrete
    {
        public string Transportadora { get; set; } = null!;
        public string CodigoTransportadora { get; set; } = null!;
        public string Servico { get; set; } = null!;
        public string CodigoServico { get; set; } = null!;
        public int PrazoEntrega { get; set; }
        public double Preco { get; set; }
    }
}
