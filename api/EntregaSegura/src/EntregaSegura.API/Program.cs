using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using EntregaSegura.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigurarCors();
builder.Services.ConfigurarIntegraçãoComIIS();
builder.Services.ConfigurarLogger();
builder.Services.ConfigurarRepositoryManager();
builder.Services.ConfigurarServiceManager();
builder.Services.ConfigurarSqlContext(builder.Configuration);

builder.Services.AddControllers().AddApplicationPart(typeof(EntregaSegura.Presentation.AssemblyReference).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
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