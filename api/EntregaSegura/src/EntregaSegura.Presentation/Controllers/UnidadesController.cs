using EntregaSegura.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

[Route("api/unidades")]
[ApiController]
public class UnidadesController : ControllerBase
{
    private readonly IServiceManager _service;

    public UnidadesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObterUnidades()
    {
        var unidades = _service.UnidadeService.ObterTodasUnidades(false);
        return Ok(unidades);
    }

    [HttpGet("{id}")]
    public IActionResult ObterUnidadePorId(Guid id)
    {
        var unidade = _service.UnidadeService.ObterUnidadePorId(id, false);

        return Ok(unidade);
    }
}