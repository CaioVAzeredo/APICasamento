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
        public async Task<IActionResult> AdicionarInformacao([FromBody] Informacoes informacoes)
        {
            if(informacoes == null){
                return BadRequest();
            }
            await _informacoesService.AdicionarAsync(informacoes);
            return CreatedAtAction(nameof(ListarTodasInformacoes), new {id=informacoes.Id}, informacoes);
        }
        [HttpPut]
        public async Task<IActionResult> AlteraInformacao([FromBody] Informacoes informacoes)
        {
            if(informacoes == null) 
            {
            return BadRequest();
            }
            await _informacoesService.AlterarAsync(informacoes);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirInformacao(int id)
        {
            await _informacoesService.ExcluirAsync(id);
            return NoContent();
        }
    }
}
