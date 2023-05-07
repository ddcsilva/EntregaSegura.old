using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EntregaSegura.Repository.Contexts;

/// <summary>
/// Classe que representa o contexto do banco de dados para a aplicação EntregaSegura.
/// </summary>
public class EntregaSeguraContext : DbContext
{
    /// <summary>
    /// Construtor que recebe as opções de configuração do contexto e as passa para a classe base DbContext.
    /// </summary>
    /// <param name="options">Opções de configuração do contexto</param>
    public EntregaSeguraContext(DbContextOptions options) : base(options) { }

    public DbSet<Condominio> Condominios => Set<Condominio>();
    public DbSet<Entrega> Entregas => Set<Entrega>();
    public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
    public DbSet<Morador> Moradores => Set<Morador>();
    public DbSet<Transportadora> Transportadoras => Set<Transportadora>();
    public DbSet<Unidade> Unidades => Set<Unidade>();

    /// <summary>
    /// Método que define a configuração do modelo de dados e aplica as configurações de mapeamento das entidades.
    /// Também popula o banco de dados com dados de exemplo.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplica as configurações de mapeamento das entidades
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntregaSeguraContext).Assembly);

        // Popula o banco de dados com dados de exemplo
        modelBuilder.SeedData();
        
        // Chama o método OnModelCreating da classe base DbContext
        base.OnModelCreating(modelBuilder);
    }
}