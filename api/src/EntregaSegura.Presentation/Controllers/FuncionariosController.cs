using EntregaSegura.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.Presentation.Controllers;

[Route("api/funcionarios")]
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

    [HttpGet("{id}")]
    public IActionResult ObterFuncionarioPorId(Guid id)
    {
        var funcionario = _service.FuncionarioService.ObterFuncionario(id, false);

        return Ok(funcionario);
    }
}