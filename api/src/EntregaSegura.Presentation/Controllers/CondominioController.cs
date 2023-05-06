using EntregaSegura.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

[Route("api/condominios")]
[ApiController]
public class CondominioController : ControllerBase
{
    private readonly IServiceManager _service;

    public CondominioController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObterCondominios()
    {
        var condominios = _service.CondominioService.ObterCondominios(false);
        return Ok(condominios);
    }

    [HttpGet("{id:guid}")]
    public IActionResult ObterCondominioPorId(Guid id)
    {
        var condominio = _service.CondominioService.ObterCondominio(id, false);
        return Ok(condominio);
    }
}