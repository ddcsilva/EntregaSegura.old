using EntregaSegura.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

[Route("api/transportadoras")]
[ApiController]
public class TransportadorasController : ControllerBase
{
    private readonly IServiceManager _service;

    public TransportadorasController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObterTransportadoras()
    {
        var transportadoras = _service.TransportadoraService.ObterTransportadoras(false);
        return Ok(transportadoras);
    }

    [HttpGet("{id}")]
    public IActionResult ObterTransportadoraPorId(Guid id)
    {
        var transportadora = _service.TransportadoraService.ObterTransportadora(id, false);

        return Ok(transportadora);
    }
}