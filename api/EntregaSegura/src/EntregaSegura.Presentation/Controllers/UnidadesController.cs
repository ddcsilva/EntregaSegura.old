using EntregaSegura.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

[Route("api/transportadoras")]
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
        try
        {
            var unidades = _service.UnidadeService.ObterTodasUnidades(false);
            return Ok(unidades);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocorreu um erro ao tentar obter todas as unidades: {ex.Message}");
        }
    }
}