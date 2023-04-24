using EntregaSegura.Business.Interfaces;
using EntregaSegura.Business.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EntregaSegura.API.Controllers;

/// <summary>
/// Classe base para os controllers
/// </summary>
[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly INotificador _notificador;

    /// <summary>
    /// Construtor padrão, recebe o notificador
    /// </summary>
    protected MainController(INotificador notificador)
    {
        _notificador = notificador;
    }

    /// <summary>
    /// Verifica se a operação foi válida (se não houver notificações de erro)
    /// </summary>
    /// <returns>Retorna se a operação é válida</returns>
    protected bool OperacaoValida()
    {
        return !_notificador.TemNotificacao();
    }

    /// <summary>
    /// Cria uma resposta personalizada com base no resultado da operação
    /// </summary>
    /// <param name="result">Resultado da operação</param>
    /// <returns>Resposta personalizada</returns>
    protected ActionResult CustomResponse(object result = null)
    {
        if (OperacaoValida())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        return BadRequest(new
        {
            success = false,
            errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
        });
    }

    /// <summary>
    /// Notifica um erro de modelo inválido
    /// </summary>
    /// <param name="modelState">Estado do modelo</param>
    /// <returns>Resposta personalizada</returns>
    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
        {
            NotificarErroModelInvalida(modelState);
        }

        return CustomResponse();
    }

    /// <summary>
    /// Notifica erros no ModelState
    /// </summary>
    /// <param name="mensagem">Mensagem de erro</param>
    protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);

        foreach (var erro in erros)
        {
            var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            NotificarErro(errorMsg);
        }
    }

    /// <summary>
    /// Envia uma notificação de erro
    /// </summary>
    /// <param name="mensagem">Mensagem de erro</param>
    protected void NotificarErro(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }
}