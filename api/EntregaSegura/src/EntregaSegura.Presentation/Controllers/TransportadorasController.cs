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
        try
        {
            var transportadoras = _service.TransportadoraService.ObterTodasTransportadoras(false);
            return Ok(transportadoras);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocorreu um erro ao tentar obter todas as transportadoras: {ex.Message}");
        }
    }
}