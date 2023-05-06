using EntregaSegura.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

[Route("api/condominios/{condominioId}/unidades/{unidadeId}/moradores/{moradorId}/entregas")]
[Route("api/condominios/{condominioId}/funcionarios/{funcionarioId}/entregas")]
[Route("api/transportadoras/{transportadoraId}/entregas")]
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
        var entregas = _service.EntregaService.ObterEntregas(false);
        return Ok(entregas);
    }

    [HttpGet("{id}")]
    public IActionResult ObterEntregaPorId(Guid id)
    {
        var entrega = _service.EntregaService.ObterEntrega(id, false);

        return Ok(entrega);
    }
}