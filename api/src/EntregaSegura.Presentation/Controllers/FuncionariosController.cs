using EntregaSegura.Service.Contracts;
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
    /// Retorna uma lista de todos os funcionários.
    /// </summary>
    /// <returns>Uma lista de objetos FuncionarioDTO.</returns>
    [HttpGet]
    public IActionResult ObterFuncionarios()
    {
        var funcionarios = _service.FuncionarioService.ObterFuncionarios(false);
        return Ok(funcionarios);
    }

    /// <summary>
    /// Retorna um funcionário com base nos IDs do condomínio e do funcionário fornecidos.
    /// </summary>
    /// <param name="condominioId">O ID do condomínio ao qual o funcionário pertence.</param>
    /// <param name="funcionarioId">O ID do funcionário a ser retornado.</param>
    /// <returns>Um objeto FuncionarioDTO correspondente aos IDs fornecidos.</returns>
    [HttpGet("{id:guid}")]
    public IActionResult ObterFuncionarioDoCondominio(Guid condominioId, Guid funcionarioId)
    {
        var funcionario = _service.FuncionarioService.ObterFuncionario(condominioId, funcionarioId, false);
        return Ok(funcionario);
    }
}