using EntregaSegura.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

[Route("api/moradores")]
[ApiController]
public class MoradoresController : ControllerBase
{
    private readonly IServiceManager _service;

    public MoradoresController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObterMoradores()
    {
        try
        {
            var moradores = _service.MoradorService.ObterTodosMoradores(false);
            return Ok(moradores);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocorreu um erro ao tentar obter todas os moradores: {ex.Message}");
        }
    }
}