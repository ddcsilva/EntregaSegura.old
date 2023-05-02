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
        var moradores = _service.MoradorService.ObterTodosMoradores(false);
        return Ok(moradores);
    }

    [HttpGet("{id}")]
    public IActionResult ObterMoradorPorId(Guid id)
    {
        var morador = _service.MoradorService.ObterMoradorPorId(id, false);

        return Ok(morador);
    }
}