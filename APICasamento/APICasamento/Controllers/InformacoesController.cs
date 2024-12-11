using APICasamento.Entities;
using APICasamento.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APICasamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InformacoesController : Controller
    {
        private readonly IInformacoesService _informacoesService;

        public InformacoesController(IInformacoesService informacoesService)
        {
            _informacoesService = informacoesService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodasInformacoes()
        {
            var informacoes = await _informacoesService.GetAllAsync();
            return Ok(informacoes);
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarInformacoes([FromBody] Informacoes informacoes)
        {
            if(informacoes == null){

            }
        }
        [HttpPut]
        [HttpDelete("{id}")]
    }
}
