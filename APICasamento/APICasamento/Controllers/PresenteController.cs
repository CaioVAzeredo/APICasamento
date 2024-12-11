using APICasamento.Entities;
using APICasamento.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APICasamento.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PresenteController : Controller
{
    private readonly IPresenteService _presenteService;

    public PresenteController(IPresenteService presenteService)
    {
        _presenteService = presenteService;
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodosPresentes()
    {
        var presentes = await _presenteService.GetAllAsync();
        return Ok(presentes);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> ListarPorId(int id)
    {
        var presente = await _presenteService.PesquisarPorId(id);

        if(presente == null)
        {
            return NotFound();
        }

        return Ok(presente);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarPresente([FromBody] Presente presente)
    {
        if (presente == null) {
            return BadRequest();
        }
        await _presenteService.AdicionarAsync(presente);
        return CreatedAtAction(nameof(ListarTodosPresentes), new {id=presente.Id }, presente);
    }
    [HttpPut]
    public async Task<IActionResult> AlterarPresente([FromBody] Presente presente)
    {
        if (presente == null)
        {
            return BadRequest();
        }
        await _presenteService.AlterarAsync(presente);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirPresente(int id)
    {
        await _presenteService.ExcluirAsync(id);
        return NoContent();
    }
}
