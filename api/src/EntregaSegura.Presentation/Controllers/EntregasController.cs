using EntregaSegura.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

/// <summary>
/// Controlador para gerenciar operações relacionadas a entregas.
/// </summary>
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

    /// <summary>
    /// Retorna uma lista de todas as entregas.
    /// </summary>
    /// <returns>Uma lista de objetos EntregaDTO.</returns>
    [HttpGet]
    public IActionResult ObterEntregas()
    {
        var entregas = _service.EntregaService.ObterEntregas(false);
        return Ok(entregas);
    }

    /// <summary>
    /// Retorna uma entrega com base no ID fornecido.
    /// </summary>
    /// <param name="id">O ID da entrega a ser retornado.</param>
    /// <returns>Um objeto EntregaDTO correspondente ao ID fornecido.</returns>
    [HttpGet("{id}")]
    public IActionResult ObterEntregaPorId(Guid id)
    {
        var entrega = _service.EntregaService.ObterEntrega(id, false);

        return Ok(entrega);
    }
}