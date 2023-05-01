using EntregaSegura.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EntregaSegura.API.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<EntregaSeguraContext>
{
    public EntregaSeguraContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<EntregaSeguraContext>()
            .UseSqlServer(configuration.GetConnectionString("SqlServerConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly("EntregaSegura.API"));

        return new EntregaSeguraContext(builder.Options);
    }
}