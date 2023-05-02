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
        var funcionarios = _service.FuncionarioService.ObterTodosFuncionarios(false);
        return Ok(funcionarios);
    }
}