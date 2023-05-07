using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

/// <summary>
/// Controlador para gerenciar operações relacionadas às unidades residenciais.
/// </summary>
[Route("api/condominios/{condominioId}/unidades")]
[ApiController]
public class UnidadesController : ControllerBase
{
    private readonly IServiceManager _service;

    public UnidadesController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna uma lista de unidades residenciais para o condomínio com o ID fornecido.
    /// </summary>
    /// <param name="condominioId">O ID do condomínio ao qual as unidades residenciais pertencem.</param>
    /// <returns>Uma lista de objetos UnidadeDTO.</returns>
    [HttpGet]
    public IActionResult ObterUnidades(Guid condominioId)
    {
        var unidades = _service.UnidadeService.ObterUnidades(condominioId, false);
        return Ok(unidades);
    }

    /// Retorna uma unidade residencial com base no ID fornecido.
    /// </summary>
    /// <param name="condominioId">O ID do condomínio ao qual a unidade residencial pertence.</param>
    /// <param name="unidadeId">O ID da unidade residencial a ser retornada.</param>
    /// <returns>Um objeto UnidadeDTO correspondente ao ID fornecido.</returns>
    [HttpGet("{unidadeId:guid}", Name = "ObterUnidadeDoCondominio")]
    public IActionResult ObterUnidadePorId(Guid condominioId, Guid unidadeId)
    {
        var unidade = _service.UnidadeService.ObterUnidade(condominioId, unidadeId, false);

        return Ok(unidade);
    }

    /// <summary>
    /// Cria uma nova unidade residencial para o condomínio com o ID fornecido.
    /// </summary>
    /// <param name="condominioId">O ID do condomínio ao qual a unidade residencial pertencerá.</param>
    /// <param name="unidade">Um objeto UnidadeCriacaoDTO contendo os dados da nova unidade residencial.</param>
    /// <returns>O objeto UnidadeDTO criado com seu ID gerado.</returns>
    [HttpPost]
    public IActionResult CriarUnidadeParaCondominio(Guid condominioId, [FromBody] UnidadeCriacaoDTO unidade)
    {
        if (unidade == null)
            return BadRequest("Unidade não pode ser nulo.");

        var unidadeCriada = _service.UnidadeService.CriarUnidadeParaCondominio(condominioId, unidade, false);

        return CreatedAtRoute("ObterUnidadeDoCondominio", new { condominioId, id = unidadeCriada.Id }, unidadeCriada);
    }
}