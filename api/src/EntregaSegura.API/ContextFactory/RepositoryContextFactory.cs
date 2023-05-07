using EntregaSegura.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EntregaSegura.API.ContextFactory;

/// <summary>
/// Classe responsável por criar uma instância do contexto do banco de dados EntregaSeguraContext em tempo de design.
/// Utilizado pelo Entity Framework Core para criar e aplicar migrações no projeto.
/// </summary>
public class RepositoryContextFactory : IDesignTimeDbContextFactory<EntregaSeguraContext>
{
    /// <summary>
    /// Método que cria uma instância do contexto EntregaSeguraContext configurado com a string de conexão
    /// do arquivo appsettings.json e o assembly de migração.
    /// </summary>
    /// <param name="args">Argumentos de linha de comando</param>
    /// <returns>Uma instância configurada do EntregaSeguraContext</returns>
    public EntregaSeguraContext CreateDbContext(string[] args)
    {
        var configuracao = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<EntregaSeguraContext>()
            .UseSqlServer(configuracao.GetConnectionString("SqlServerConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly("EntregaSegura.API"));

        return new EntregaSeguraContext(builder.Options);
    }
}