using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

[Route("api/condominios")]
[ApiController]
public class CondominioController : ControllerBase
{
    private readonly IServiceManager _service;

    public CondominioController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObterCondominios()
    {
        var condominios = _service.CondominioService.ObterCondominios(false);
        return Ok(condominios);
    }

    [HttpGet("{id:guid}", Name = "CondominioPorId")]
    public IActionResult ObterCondominio(Guid id)
    {
        var condominio = _service.CondominioService.ObterCondominio(id, false);
        return Ok(condominio);
    }

    [HttpPost]
    public IActionResult CriarCondominio([FromBody] CondominioCriacaoDTO condominio)
    {
        if (condominio == null)
            return BadRequest("Condomínio não foi informado.");

        var condominioCriado = _service.CondominioService.CriarCondominio(condominio);

        return CreatedAtRoute("CondominioPorId", new { id = condominioCriado.Id }, condominioCriado);
    }
}