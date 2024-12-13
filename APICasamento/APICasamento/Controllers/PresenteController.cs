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
        try
        {
            var presentess = await _presenteService.GetAllAsync();
            return Ok(presentess);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno ao listar presentes.", Detalhes = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ListarPorId(int id)
    {
        try
        {
            var presente = await _presenteService.PesquisarPorId(id);

            if (presente == null)
            {
                return NotFound(new { Message = $"Presente com ID {id} não encontrado." });
            }

            return Ok(presente);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno ao buscar presente.", Detalhes = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarPresente([FromBody] Presente presente)
    {
        try
        {
            if (presente == null)
            {
                return BadRequest(new { Message = "Dados inválidos para o presente." });
            }

            await _presenteService.AdicionarAsync(presente);
            return CreatedAtAction(nameof(ListarPorId), new { id = presente.Id }, presente);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno ao adicionar presente.", Detalhes = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> AlterarPresente([FromBody] Presente presente)
    {
        try
        {
            if (presente == null)
            {
                return BadRequest(new { Message = "Dados inválidos para o presente." });
            }

            await _presenteService.AlterarAsync(presente);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno ao alterar presente.", Detalhes = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirPresente(int id)
    {
        try
        {
            await _presenteService.ExcluirAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno ao excluir presente.", Detalhes = ex.Message });
        }
    }
}
