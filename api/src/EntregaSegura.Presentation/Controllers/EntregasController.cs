using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

/// <summary>
/// Controlador para gerenciar operações relacionadas a entregas.
/// </summary>
[Route("api")]
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
    [HttpGet("condominios/{condominioId}/unidades/{unidadeId}/moradores/{moradorId}/entregas")]
    [HttpGet("condominios/{condominioId}/funcionarios/{funcionarioId}/entregas")]
    [HttpGet("transportadoras/{transportadoraId}/entregas")]
    public IActionResult ObterEntregas(Guid? condominioId = null, Guid? unidadeId = null, Guid? moradorId = null, Guid? funcionarioId = null, Guid? transportadoraId = null)
    {
        var entregas = _service.EntregaService.ObterEntregas(condominioId, unidadeId, moradorId, funcionarioId, transportadoraId, false);

        return Ok(entregas);
    }

    [HttpGet("condominios/{condominioId}/unidades/{unidadeId}/moradores/{moradorId}/entregas/{entregaId}", Name = "ObterEntregaPorMorador")]
    public IActionResult ObterEntregaPorMorador(Guid condominioId, Guid unidadeId, Guid moradorId, Guid entregaId)
    {
        var entrega = _service.EntregaService.ObterEntregaPorMorador(condominioId, unidadeId, moradorId, entregaId, false);

        return Ok(entrega);
    }

    [HttpGet("condominios/{condominioId}/funcionarios/{funcionarioId}/entregas/{entregaId}", Name = "ObterEntregaPorFuncionario")]
    public IActionResult ObterEntregaPorFuncionario(Guid condominioId, Guid funcionarioId, Guid entregaId)
    {
        var entrega = _service.EntregaService.ObterEntregaPorFuncionario(condominioId, funcionarioId, entregaId, false);

        return Ok(entrega);
    }

    [HttpGet("transportadoras/{transportadoraId}/entregas/{entregaId}", Name = "ObterEntregaPorTransportadora")]
    public IActionResult ObterEntregaPorTransportadora(Guid transportadoraId, Guid entregaId)
    {
        var entrega = _service.EntregaService.ObterEntregaPorTransportadora(transportadoraId, entregaId, false);

        return Ok(entrega);
    }

    [HttpPost("condominios/{condominioId}/funcionarios/{funcionarioId}/entregas")]
    public IActionResult RegistrarEntrega(Guid condominioId, Guid funcionarioId, [FromBody] EntregaCriacaoDTO entrega)
    {
        if (entrega == null)
            return BadRequest("Entrega não pode ser nula.");

        var entregaCriada = _service.EntregaService.RegistrarEntrega(condominioId, funcionarioId, entrega, false);

        return CreatedAtRoute("ObterEntregaPorFuncionario", new { condominioId, funcionarioId, entregaId = entregaCriada.Id }, entregaCriada);
    }
}