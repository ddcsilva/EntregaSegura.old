using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

/// <summary>
/// Controlador para gerenciar operações relacionadas a transportadoras.
/// </summary>
[Route("api/transportadoras")]
[ApiController]
public class TransportadorasController : ControllerBase
{
    private readonly IServiceManager _service;

    public TransportadorasController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna uma lista de todas as transportadoras.
    /// </summary>
    /// <returns>Uma lista de objetos TransportadoraDTO.</returns>
    [HttpGet]
    public IActionResult ObterTransportadoras()
    {
        var transportadoras = _service.TransportadoraService.ObterTransportadoras(false);
        return Ok(transportadoras);
    }

    /// <summary>
    /// Retorna uma transportadora com base no ID fornecido.
    /// </summary>
    /// <param name="id">O ID da transportadora a ser retornado.</param>
    /// <returns>Um objeto TransportadoraDTO correspondente ao ID fornecido.</returns>
    [HttpGet("{id}", Name = "TransportadoraPorId")]
    public IActionResult ObterTransportadoraPorId(Guid id)
    {
        var transportadora = _service.TransportadoraService.ObterTransportadora(id, false);

        return Ok(transportadora);
    }

    /// <summary>
    /// Cria uma nova transportadora com os dados fornecidos.
    /// </summary>
    /// <param name="transportadora">Um objeto TransportadoraCriacaoDTO contendo os dados da nova transportadora.</param>
    /// <returns>O objeto TransportadoraDTO criado com seu ID gerado.</returns>
    [HttpPost]
    public IActionResult CriarTransportadora([FromBody] TransportadoraCriacaoDTO transportadora)
    {
        if (transportadora == null)
            return BadRequest("Transportadora não foi informada.");

        var transportadoraCriada = _service.TransportadoraService.CriarTransportadora(transportadora);

        return CreatedAtRoute("TransportadoraPorId", new { id = transportadoraCriada.Id }, transportadoraCriada);
    }
}