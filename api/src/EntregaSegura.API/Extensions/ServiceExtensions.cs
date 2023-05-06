using EntregaSegura.Contracts;
using EntregaSegura.LoggerService;
using EntregaSegura.Repository;
using EntregaSegura.Repository.Contexts;
using EntregaSegura.Service;
using EntregaSegura.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EntregaSegura.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigurarCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }

    public static void ConfigurarIntegraçãoComIIS(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options =>
        {

        });
    }

    public static void ConfigurarLogger(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfigurarRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    public static void ConfigurarServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }

    public static void ConfigurarSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EntregaSeguraContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));
    }
}