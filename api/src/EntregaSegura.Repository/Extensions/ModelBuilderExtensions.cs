using EntregaSegura.Entities.Models;
using EntregaSegura.Entities.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EntregaSegura.Repository.Extensions;

public static class ModelBuilderExtensions
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
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
            Email = "morador@email.com",
            Telefone = "11999999999",
            Status = StatusConta.Aprovada,
            UnidadeId = unidadeId
        });

        modelBuilder.Entity<Funcionario>().HasData(new Funcionario
        {
            Id = funcionarioId,
            Nome = "Funcionario Exemplo",
            CPF = "98765432109",
            Email = "funcionario@email.com",
            Telefone = "11999999999",
            Status = StatusConta.Aprovada,
            Cargo = CargoFuncionario.Porteiro,
            CondominioId = condominioId
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
            MoradorId = moradorId,
            FuncionarioId = funcionarioId
        });
    }
}
