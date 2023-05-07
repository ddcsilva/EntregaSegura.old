using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

/// <summary>
/// Controlador para gerenciar operações relacionadas a moradores.
/// </summary>
[Route("api/condominios/{condominioId}/unidades/{unidadeId}/moradores")]
[ApiController]
public class MoradoresController : ControllerBase
{
    private readonly IServiceManager _service;

    public MoradoresController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna uma lista de moradores para o condomínio e unidade residencial com os IDs fornecidos.
    /// </summary>
    /// <returns>Uma lista de objetos MoradorDTO.</returns>
    [HttpGet]
    public IActionResult ObterMoradores(Guid condominioId, Guid unidadeId)
    {
        var moradores = _service.MoradorService.ObterMoradores(condominioId, unidadeId, false);
        return Ok(moradores);
    }

    /// <summary>
    /// Retorna um morador para o condomínio, unidade residencial e morador com os IDs fornecidos.
    /// </summary>
    /// <param name="condominioId">O ID do condomínio ao qual o funcionário pertence.</param>
    /// <param name="unidadeId">O ID da unidade residencial à qual o morador pertence.</param>
    /// <param name="moradorId">O ID do morador a ser retornado.</param>
    /// <returns>Um objeto MoradorDTO correspondente ao ID fornecido.</returns>
    [HttpGet("{moradorId}", Name = "ObterMoradorDaUnidade")]
    public IActionResult ObterMoradorPorId(Guid condominioId, Guid unidadeId, Guid moradorId)
    {
        var morador = _service.MoradorService.ObterMorador(condominioId, unidadeId, moradorId, false);
        return Ok(morador);
    }

    /// <summary>
    /// Cria um novo morador para o condomínio, unidade residencial e morador com os IDs fornecidos.
    /// </summary>
    /// <param name="condominioId">O ID do condomínio ao qual o funcionário pertence.</param>
    /// <param name="unidadeId">O ID da unidade residencial à qual o morador pertence.</param>
    /// <param name="morador">Um objeto MoradorCriacaoDTO contendo os dados do novo morador.</param>
    /// <returns>O objeto MoradorDTO criado com seu ID gerado.</returns>
    [HttpPost]
    public IActionResult CriarMoradorParaUnidade(Guid condominioId, Guid unidadeId, [FromBody] MoradorCriacaoDTO morador)
    {
        if (morador == null)
            return BadRequest("Morador não pode ser nulo.");

        var moradorCriado = _service.MoradorService.CriarMoradorParaUnidade(condominioId, unidadeId, morador, false);

        return CreatedAtRoute("ObterMoradorPorId", new { condominioId, unidadeId, id = moradorCriado.Id }, moradorCriado);
    }
}