using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using EntregaSegura.API.Extensions;
using EntregaSegura.Contracts;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigurarCors();
builder.Services.ConfigurarIntegraçãoComIIS();
builder.Services.ConfigurarLogger();
builder.Services.ConfigurarRepositoryManager();
builder.Services.ConfigurarServiceManager();
builder.Services.ConfigurarSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers().AddApplicationPart(typeof(EntregaSegura.Presentation.AssemblyReference).Assembly);

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigurarExceptionHandler(logger);

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();