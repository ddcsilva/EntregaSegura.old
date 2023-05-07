using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

/// <summary>
/// Controlador para gerenciar operações relacionadas a condomínios.
/// </summary>
[Route("api/condominios")]
[ApiController]
public class CondominioController : ControllerBase
{
    private readonly IServiceManager _service;
    
    public CondominioController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna uma lista de todos os condomínios.
    /// </summary>
    /// <returns>Uma lista de objetos CondominioDTO.</returns>
    [HttpGet]
    public IActionResult ObterCondominios()
    {
        var condominios = _service.CondominioService.ObterCondominios(false);
        return Ok(condominios);
    }

    /// <summary>
    /// Retorna um condomínio com base no ID fornecido.
    /// </summary>
    /// <param name="id">O ID do condomínio a ser retornado.</param>
    /// <returns>Um objeto CondominioDTO correspondente ao ID fornecido.</returns>
    [HttpGet("{id:guid}", Name = "CondominioPorId")]
    public IActionResult ObterCondominio(Guid id)
    {
        var condominio = _service.CondominioService.ObterCondominio(id, false);
        return Ok(condominio);
    }

    /// <summary>
    /// Cria um novo condomínio com os dados fornecidos.
    /// </summary>
    /// <param name="condominio">Um objeto CondominioCriacaoDTO contendo os dados do novo condomínio.</param>
    /// <returns>O objeto CondominioDTO criado com seu ID gerado.</returns>
    [HttpPost]
    public IActionResult CriarCondominio([FromBody] CondominioCriacaoDTO condominio)
    {
        if (condominio == null)
            return BadRequest("Condomínio não foi informado.");

        var condominioCriado = _service.CondominioService.CriarCondominio(condominio);

        return CreatedAtRoute("CondominioPorId", new { id = condominioCriado.Id }, condominioCriado);
    }
}