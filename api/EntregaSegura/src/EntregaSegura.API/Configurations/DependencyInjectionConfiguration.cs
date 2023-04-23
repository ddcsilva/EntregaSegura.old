using EntregaSegura.Business.Interfaces;
using EntregaSegura.Business.Utils;
using EntregaSegura.Data.Contexts;

namespace EntregaSegura.API.Configurations;

/// <summary>
/// Classe de configuração de injeção de dependência
/// </summary>
public static class DependencyInjectionConfiguration
{
    /// <summary>
    /// Método de extensão para adicionar as dependências
    /// </summary>
    /// <param name="services">Coleção de serviços</param>
    /// <returns>Coleção de serviços</returns>
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<EntregaSeguraContext>();

        services.AddScoped<INotificador, Notificador>();

        return services;
    }
}
