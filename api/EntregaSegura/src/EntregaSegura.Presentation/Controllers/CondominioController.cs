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
        var condominios = _service.CondominioService.ObterTodosCondominios(false);
        return Ok(condominios);
    }
}