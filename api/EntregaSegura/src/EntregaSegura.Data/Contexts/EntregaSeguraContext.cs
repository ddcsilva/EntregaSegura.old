using EntregaSegura.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace EntregaSegura.Data.Contexts;

/// <summary>
/// Classe que representa o contexto do banco de dados
/// </summary>
public class EntregaSeguraContext : DbContext
{
    /// <summary>
    /// Construtor que recebe as opções de configuração do contexto
    /// </summary>
    /// <param name="options">Opções de configuração do contexto</param>
    public EntregaSeguraContext(DbContextOptions<EntregaSeguraContext> options) : base(options) { }

    public DbSet<Condominio> Condominios { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Entrega> Entregas { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Morador> Moradores { get; set; }
    public DbSet<Transportadora> Transportadoras { get; set; }
    public DbSet<Unidade> Unidades { get; set; }

    /// <summary>
    /// Método que configura o contexto do banco de dados
    /// </summary>
    /// <param name="modelBuilder">Objeto que representa o modelo do banco de dados</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplica as configurações de mapeamento das entidades
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntregaSeguraContext).Assembly);

        // Configuração para que o banco de dados utilize o tipo varchar ao invés de nvarchar
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
        {
            property.SetColumnType("varchar(100)");
        }

        // Configuração para que o banco de dados utilize o tipo decimal ao invés de double
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(decimal))))
        {
            property.SetColumnType("decimal(18,2)");
        }

        // Configuração para que o banco de dados utilize o tipo datetime ao invés de datetime2
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(DateTime))))
        {
            property.SetColumnType("datetime");
        }
        
        base.OnModelCreating(modelBuilder);
    }
}