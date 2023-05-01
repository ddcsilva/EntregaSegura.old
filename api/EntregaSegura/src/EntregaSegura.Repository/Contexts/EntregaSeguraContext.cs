using EntregaSegura.Entities.Models;
using EntregaSegura.Entities.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EntregaSegura.Repository.Contexts;

public class EntregaSeguraContext : DbContext
{
    public EntregaSeguraContext(DbContextOptions options) : base(options) { }

    public DbSet<Condominio>? Condominios { get; set; }
    public DbSet<Endereco>? Enderecos { get; set; }
    public DbSet<Entrega>? Entregas { get; set; }
    public DbSet<Funcionario>? Funcionarios { get; set; }
    public DbSet<Morador>? Moradores { get; set; }
    public DbSet<Transportadora>? Transportadoras { get; set; }
    public DbSet<Unidade>? Unidades { get; set; }

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

        // Dados iniciais
        var condominioId = Guid.NewGuid();
        var enderecoId = Guid.NewGuid();
        var unidadeId = Guid.NewGuid();
        var moradorId = Guid.NewGuid();
        var funcionarioId = Guid.NewGuid();
        var transportadoraId = Guid.NewGuid();
        var entregaId = Guid.NewGuid();

        modelBuilder.Entity<Condominio>().HasData(new Condominio
        {
            Id = condominioId,
            Nome = "Condomínio Exemplo",
            CNPJ = "11111111111111",
            Telefone = "11999999999",
            Email = "contato@condominioexemplo.com.br"
        });

        modelBuilder.Entity<Endereco>().HasData(new Endereco
        {
            Id = enderecoId,
            CondominioId = condominioId,
            Logradouro = "Rua Exemplo",
            Numero = "100",
            Complemento = "Bloco A",
            CEP = "11111111",
            Bairro = "Bairro Exemplo",
            Cidade = "Cidade Exemplo",
            Estado = "SP"
        });

        modelBuilder.Entity<Unidade>().HasData(new Unidade
        {
            Id = unidadeId,
            CondominioId = condominioId,
            Numero = "101",
            Bloco = "A"
        });

        modelBuilder.Entity<Morador>().HasData(new Morador
        {
            Id = moradorId,
            Nome = "Morador Exemplo",
            CPF = "12345678901",
            Status = StatusConta.Aprovada,
            UnidadeId = unidadeId
        });

        modelBuilder.Entity<Funcionario>().HasData(new Funcionario
        {
            Id = funcionarioId,
            Nome = "Funcionario Exemplo",
            CPF = "98765432109",
            Status = StatusConta.Aprovada,
            Cargo = CargoFuncionario.Porteiro
        });

        modelBuilder.Entity<Transportadora>().HasData(new Transportadora
        {
            Id = transportadoraId,
            Nome = "Transportadora Exemplo",
            CNPJ = "22222222222222",
            Telefone = "11988888888",
            Email = "contato@transportadoraexemplo.com.br"
        });

        modelBuilder.Entity<Entrega>().HasData(new Entrega
        {
            Id = entregaId,
            Remetente = "Remetente Exemplo",
            Destinatario = "Destinatario Exemplo",
            DataRecebimento = DateTime.Now,
            Descricao = "Descrição da entrega",
            Observacao = "Observação da entrega",
            Status = StatusEntrega.Recebida,
            TransportadoraId = transportadoraId,
            UnidadeId = unidadeId,
            MoradorId = moradorId,
            FuncionarioId = funcionarioId
        });

        base.OnModelCreating(modelBuilder);
    }
}