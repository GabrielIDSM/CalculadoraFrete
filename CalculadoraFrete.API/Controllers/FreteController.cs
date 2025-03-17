using CalculadoraFrete.Domain.Entities;
using CalculadoraFrete.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraFrete.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FreteController(IFreteService freteService) : Controller
    {
        private readonly IFreteService _freteService = freteService;

        [HttpPost(Name = "Cotacao")]
        public Resposta Post(ParametroEnvio? parametroEnvio)
        {
            return _freteService.ObterCotacoes(parametroEnvio);
        }
    }
}
