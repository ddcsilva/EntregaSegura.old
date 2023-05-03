using System.Net;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.ErrorModel;
using EntregaSegura.Entities.Exceptions;
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