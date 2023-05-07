using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

/// <summary>
/// Controlador para gerenciar operações relacionadas a funcionários.
/// </summary>
[Route("api/condominios/{condominioId}/funcionarios")]
[ApiController]
public class FuncionariosController : ControllerBase
{
    private readonly IServiceManager _service;

    public FuncionariosController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna uma lista de funcionários para o condomínio com o ID fornecido.
    /// </summary>
    /// <returns>Uma lista de objetos FuncionarioDTO.</returns>
    [HttpGet]
    public IActionResult ObterFuncionariosDoCondominio(Guid condominioId)
    {
        var funcionarios = _service.FuncionarioService.ObterFuncionarios(condominioId, false);
        return Ok(funcionarios);
    }

    /// <summary>
    /// Retorna um funcionário com base nos IDs do condomínio e do funcionário fornecidos.
    /// </summary>
    /// <param name="condominioId">O ID do condomínio ao qual o funcionário pertence.</param>
    /// <param name="funcionarioId">O ID do funcionário a ser retornado.</param>
    /// <returns>Um objeto FuncionarioDTO correspondente aos IDs fornecidos.</returns>
    [HttpGet("{funcionarioId:guid}", Name = "ObterFuncionarioDoCondominio")]
    public IActionResult ObterFuncionarioDoCondominio(Guid condominioId, Guid funcionarioId)
    {
        var funcionario = _service.FuncionarioService.ObterFuncionario(condominioId, funcionarioId, false);
        return Ok(funcionario);
    }

    /// <summary>
    /// Cria um novo funcionário para o condomínio com o ID fornecido.
    /// </summary>
    /// <param name="condominioId">O ID do condomínio ao qual o funcionário pertencerá.</param>
    /// <param name="funcionario">Um objeto FuncionarioCriacaoDTO contendo os dados do novo funcionário.</param>
    /// <returns>O objeto FuncionarioDTO criado com seu ID gerado.</returns>
    [HttpPost]
    public IActionResult CriarFuncionarioParaCondominio(Guid condominioId, [FromBody] FuncionarioCriacaoDTO funcionario)
    {
        if (funcionario == null)
            return BadRequest("Funcionário não pode ser nulo.");

        var funcionarioCriado = _service.FuncionarioService.CriarFuncionarioParaCondominio(condominioId, funcionario, false);

        return CreatedAtRoute("ObterFuncionarioDoCondominio", new { condominioId, id = funcionarioCriado.Id }, funcionarioCriado);
    }
}