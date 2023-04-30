using EntregaSegura.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EntregaSegura.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options) { }

    public DbSet<Condominio>? Condominios { get; set; }
    public DbSet<Empresa>? Empresas { get; set; }
    public DbSet<Endereco>? Enderecos { get; set; }
    public DbSet<Entrega>? Entregas { get; set; }
    public DbSet<Funcionario>? Funcionarios { get; set; }
    public DbSet<Morador>? Moradores { get; set; }
    public DbSet<Transportadora>? Transportadoras { get; set; }
    public DbSet<Unidade>? Unidades { get; set; }
    public DbSet<Usuario>? Usuarios { get; set; }
}