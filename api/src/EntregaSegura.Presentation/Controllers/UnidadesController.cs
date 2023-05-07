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
    /// Retorna uma lista de todas as unidades residenciais.
    /// </summary>
    /// <returns>Uma lista de objetos UnidadeDTO.</returns>
    [HttpGet]
    public IActionResult ObterUnidades()
    {
        var unidades = _service.UnidadeService.ObterUnidades(false);
        return Ok(unidades);
    }

    /// Retorna uma unidade residencial com base no ID fornecido.
    /// </summary>
    /// <param name="id">O ID da unidade residencial a ser retornado.</param>
    /// <returns>Um objeto UnidadeDTO correspondente ao ID fornecido.</returns>
    [HttpGet("{id:guid}", Name = "ObterUnidadeDoCondominio")]
    public IActionResult ObterUnidadePorId(Guid id)
    {
        var unidade = _service.UnidadeService.ObterUnidade(id, false);

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