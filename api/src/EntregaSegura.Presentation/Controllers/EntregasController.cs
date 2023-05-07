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
    /// Retorna uma lista de todas as entregas, filtradas pelos IDs de condomínio, unidade, morador, funcionário e/ou transportadora fornecidos.
    /// </summary>
    /// <param name="condominioId">Opcional: ID do condomínio para filtrar as entregas.</param>
    /// <param name="unidadeId">Opcional: ID da unidade para filtrar as entregas.</param>
    /// <param name="moradorId">Opcional: ID do morador para filtrar as entregas.</param>
    /// <param name="funcionarioId">Opcional: ID do funcionário para filtrar as entregas.</param>
    /// <param name="transportadoraId">Opcional: ID da transportadora para filtrar as entregas.</param>
    /// <returns>Uma lista de objetos EntregaDTO.</returns>
    [HttpGet("condominios/{condominioId}/unidades/{unidadeId}/moradores/{moradorId}/entregas")]
    [HttpGet("condominios/{condominioId}/funcionarios/{funcionarioId}/entregas")]
    [HttpGet("transportadoras/{transportadoraId}/entregas")]
    public IActionResult ObterEntregas(Guid? condominioId = null, Guid? unidadeId = null, Guid? moradorId = null, Guid? funcionarioId = null, Guid? transportadoraId = null)
    {
        var entregas = _service.EntregaService.ObterEntregas(condominioId, unidadeId, moradorId, funcionarioId, transportadoraId, false);

        return Ok(entregas);
    }

    /// <summary>
    /// Retorna uma entrega específica para um morador, com base nos IDs fornecidos.
    /// </summary>
    /// <param name="condominioId">O ID do condomínio.</param>
    /// <param name="unidadeId">O ID da unidade.</param>
    /// <param name="moradorId">O ID do morador.</param>
    /// <param name="entregaId">O ID da entrega a ser obtida.</param>
    /// <returns>Um objeto EntregaDTO correspondente aos IDs fornecidos.</returns>
    [HttpGet("condominios/{condominioId}/unidades/{unidadeId}/moradores/{moradorId}/entregas/{entregaId}", Name = "ObterEntregaPorMorador")]
    public IActionResult ObterEntregaPorMorador(Guid condominioId, Guid unidadeId, Guid moradorId, Guid entregaId)
    {
        var entrega = _service.EntregaService.ObterEntregaPorMorador(condominioId, unidadeId, moradorId, entregaId, false);

        return Ok(entrega);
    }

    /// <summary>
    /// Retorna uma entrega específica para um funcionário, com base nos IDs fornecidos.
    /// </summary>
    /// <param name="condominioId">O ID do condomínio.</param>
    /// <param name="funcionarioId">O ID do funcionário.</param>
    /// <param name="entregaId">O ID da entrega a ser obtida.</param>
    /// <returns>Um objeto EntregaDTO correspondente aos IDs fornecidos.</returns>
    [HttpGet("condominios/{condominioId}/funcionarios/{funcionarioId}/entregas/{entregaId}", Name = "ObterEntregaPorFuncionario")]
    public IActionResult ObterEntregaPorFuncionario(Guid condominioId, Guid funcionarioId, Guid entregaId)
    {
        var entrega = _service.EntregaService.ObterEntregaPorFuncionario(condominioId, funcionarioId, entregaId, false);

        return Ok(entrega);
    }

    /// <summary>
    /// Retorna uma entrega específica para uma transportadora, com base nos IDs fornecidos.
    /// </summary>
    /// <param name="transportadoraId">O ID da transportadora.</param>
    /// <param name="entregaId">O ID da entrega a ser obtida.</param>
    /// <returns>Um objeto EntregaDTO correspondente aos IDs fornecidos.</returns>
    [HttpGet("transportadoras/{transportadoraId}/entregas/{entregaId}", Name = "ObterEntregaPorTransportadora")]
    public IActionResult ObterEntregaPorTransportadora(Guid transportadoraId, Guid entregaId)
    {
        var entrega = _service.EntregaService.ObterEntregaPorTransportadora(transportadoraId, entregaId, false);

        return Ok(entrega);
    }

    /// <summary>
    /// Registra uma nova entrega associada a um condomínio e funcionário específicos.
    /// </summary>
    /// <param name="condominioId">O ID do condomínio onde a entrega será registrada.</param>
    /// <param name="funcionarioId">O ID do funcionário que registra a entrega.</param>
    /// <param name="entrega">Um objeto EntregaCriacaoDTO contendo os dados da entrega a ser registrada.</param>
    /// <returns>Um objeto EntregaDTO da entrega criada.</returns>
    [HttpPost("condominios/{condominioId}/funcionarios/{funcionarioId}/entregas")]
    public IActionResult RegistrarEntrega(Guid condominioId, Guid funcionarioId, [FromBody] EntregaCriacaoDTO entrega)
    {
        if (entrega == null)
            return BadRequest("Entrega não pode ser nula.");

        var entregaCriada = _service.EntregaService.RegistrarEntrega(condominioId, funcionarioId, entrega, false);

        return CreatedAtRoute("ObterEntregaPorFuncionario", new { condominioId, funcionarioId, entregaId = entregaCriada.Id }, entregaCriada);
    }
}