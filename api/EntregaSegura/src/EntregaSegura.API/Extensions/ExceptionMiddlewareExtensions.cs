using System.Net;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;

namespace EntregaSegura.API.Extensions;

public static class ExceptionMiddlewareExtensions
{
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
                    logger.LogErro($"Algo deu errado: {contextFeature.Error}");

                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Mensagem = "Erro Interno no Servidor"
                    }.ToString());
                }
            });
        });
    }
}