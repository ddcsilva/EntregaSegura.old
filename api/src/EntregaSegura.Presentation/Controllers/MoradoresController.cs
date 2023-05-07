using EntregaSegura.Service.Contracts;
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
    /// Retorna uma lista de todos os moradores.
    /// </summary>
    /// <returns>Uma lista de objetos MoradorDTO.</returns>
    [HttpGet]
    public IActionResult ObterMoradores()
    {
        var moradores = _service.MoradorService.ObterMoradores(false);
        return Ok(moradores);
    }

    /// <summary>
    /// Retorna um morador com base no ID fornecido.
    /// </summary>
    /// <param name="id">O ID do morador a ser retornado.</param>
    /// <returns>Um objeto MoradorDTO correspondente ao ID fornecido.</returns>
    [HttpGet("{id}")]
    public IActionResult ObterMoradorPorId(Guid id)
    {
        var morador = _service.MoradorService.ObterMorador(id, false);

        return Ok(morador);
    }
}