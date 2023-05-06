using EntregaSegura.Entities.Models;
using EntregaSegura.Entities.Models.Enums;
using EntregaSegura.Repository.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EntregaSegura.Repository.Contexts;

public class EntregaSeguraContext : DbContext
{
    public EntregaSeguraContext(DbContextOptions options) : base(options) { }

    public DbSet<Condominio> Condominios => Set<Condominio>();
    public DbSet<Endereco> Enderecos => Set<Endereco>();
    public DbSet<Entrega> Entregas => Set<Entrega>();
    public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
    public DbSet<Morador> Moradores => Set<Morador>();
    public DbSet<Transportadora> Transportadoras => Set<Transportadora>();
    public DbSet<Unidade> Unidades => Set<Unidade>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplica as configurações de mapeamento das entidades
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntregaSeguraContext).Assembly);

        // Popula o banco de dados com dados de exemplo
        modelBuilder.SeedData();

        base.OnModelCreating(modelBuilder);
    }
}