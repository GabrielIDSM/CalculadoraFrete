namespace CalculadoraFrete.Domain.Entities
{
    public class ParametroEnvio
    {
        public string CEPOrigem { get; set; } = null!;
        public string CEPDestino { get; set; } = null!;
        public double Peso { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }
        public int Comprimento { get; set; }
        public double ValorDeclarado { get; set; }
    }
}
