using EntregaSegura.Contracts;
using EntregaSegura.LoggerService;
using EntregaSegura.Repository;
using EntregaSegura.Repository.Contexts;
using EntregaSegura.Service;
using EntregaSegura.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EntregaSegura.API.Extensions;

/// <summary>
/// Classe que contém métodos de extensão para configurar diversos aspectos da aplicação.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Configura a política de CORS para permitir qualquer origem, método e cabeçalho.
    /// </summary>
    /// <param name="services">Instância do IServiceCollection</param>
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

    /// <summary>
    /// Configura a integração com o IIS.
    /// </summary>
    /// <param name="services">Instância do IServiceCollection</param>
    public static void ConfigurarIntegraçãoComIIS(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options =>
        {

        });
    }

    /// <summary>
    /// Configura e registra o serviço de log.
    /// </summary>
    /// <param name="services">Instância do IServiceCollection</param>
    public static void ConfigurarLogger(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    /// <summary>
    /// Configura e registra o gerenciador de repositórios.
    /// </summary>
    /// <param name="services">Instância do IServiceCollection</param>
    public static void ConfigurarRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    /// <summary>
    /// Configura e registra o gerenciador de serviços.
    /// </summary>
    /// <param name="services">Instância do IServiceCollection</param>
    public static void ConfigurarServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }

    /// <summary>
    /// Configura e registra o contexto do Entity Framework usando a conexão SQL Server.
    /// </summary>
    /// <param name="services">Instância do IServiceCollection</param>
    /// <param name="configuration">Instância do IConfiguration</param>
    public static void ConfigurarSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EntregaSeguraContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));
    }
}