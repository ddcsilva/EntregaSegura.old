using EntregaSegura.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

[Route("api/condominios/{condominioId}/funcionarios")]
[ApiController]
public class FuncionariosController : ControllerBase
{
    private readonly IServiceManager _service;

    public FuncionariosController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ObterFuncionarios()
    {
        var funcionarios = _service.FuncionarioService.ObterFuncionarios(false);
        return Ok(funcionarios);
    }

    [HttpGet("{id:guid}")]
    public IActionResult ObterFuncionarioDoCondominio(Guid condominioId, Guid funcionarioId)
    {
        var funcionario = _service.FuncionarioService.ObterFuncionario(condominioId, funcionarioId, false);
        return Ok(funcionario);
    }
}