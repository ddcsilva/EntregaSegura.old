using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

[Route("api/condominios/{condominioId}/unidades")]
[ApiController]
public class UnidadesController : ControllerBase
{
    private readonly IServiceManager _service;

    public UnidadesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObterUnidades()
    {
        var unidades = _service.UnidadeService.ObterUnidades(false);
        return Ok(unidades);
    }

    [HttpGet("{id:guid}", Name = "ObterUnidadeDoCondominio")]
    public IActionResult ObterUnidadePorId(Guid id)
    {
        var unidade = _service.UnidadeService.ObterUnidade(id, false);

        return Ok(unidade);
    }

    [HttpPost]
    public IActionResult CriarUnidadeParaCondominio(Guid condominioId, [FromBody] UnidadeCriacaoDTO unidade)
    {
        if (unidade == null)
            return BadRequest("Unidade não pode ser nulo.");

        var unidadeCriada = _service.UnidadeService.CriarUnidadeParaCondominio(condominioId, unidade, false);

        return CreatedAtRoute("ObterUnidadeDoCondominio", new { condominioId, id = unidadeCriada.Id }, unidadeCriada);
    }
}