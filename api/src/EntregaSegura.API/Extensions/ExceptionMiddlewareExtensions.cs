using System.Net;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.ErrorModel;
using EntregaSegura.Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace EntregaSegura.API.Extensions;

/// <summary>
/// Classe que contém extensão de método para configurar o middleware de tratamento de exceções personalizado.
/// </summary>
public static class ExceptionMiddlewareExtensions
{
    /// <summary>
    /// Configura o middleware de tratamento de exceções personalizado para capturar exceções e retornar
    /// um objeto JSON com detalhes do erro.
    /// </summary>
    /// <param name="app">Instância do aplicativo WebApplication</param>
    /// <param name="logger">Instância do logger</param>
    public static void ConfigurarExceptionHandler(this WebApplication app, ILoggerManager logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => (int)HttpStatusCode.NotFound,
                        _ => (int)HttpStatusCode.InternalServerError
                    };

                    logger.LogErro($"Algo deu errado: {contextFeature.Error}");

                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Mensagem = contextFeature.Error.Message
                    }.ToString());
                }
            });
        });
    }
}