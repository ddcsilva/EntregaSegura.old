using EntregaSegura.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

[Route("api/entregas")]
[ApiController]
public class EntregasController : ControllerBase
{
    private readonly IServiceManager _service;

    public EntregasController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObterEntregas()
    {
        try
        {
            var entregas = _service.EntregaService.ObterTodasEntregas(false);
            return Ok(entregas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocorreu um erro ao tentar obter todas as entregas: {ex.Message}");
        }
    }
}