using APICasamento_Teste.Entities;
using APICasamento_Teste.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APICasamento_Teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FormularioController : Controller
    {
        private readonly IFormularioService _formularioService;

        public FormularioController(IFormularioService formulario)
        {
            _formularioService = formulario;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodosFormularios()
        {
            var formulario = await _formularioService.GetAllAsync();
            return Ok(formulario);
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarFormulario([FromBody] Formulario formulario)
        {
            if (formulario == null)
            {
                return BadRequest();
            }
            await _formularioService.AdicionarAsync(formulario);
            return CreatedAtAction(nameof(ListarTodosFormularios), new { id = formulario.Id, formulario });
        }
    }
}
