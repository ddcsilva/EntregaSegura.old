using EntregaSegura.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntregaSegura.Repository.Configurations;

public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("TB_FUNCIONARIOS");

        builder.HasKey(f => f.Id)
            .HasName("PK_FUNCIONARIOS");

        builder.Property(f => f.Id)
            .HasColumnName("FUN_ID")
            .HasColumnOrder(1)
            .HasComment("Chave primária do funcionário");

        builder.Property(f => f.Nome)
            .HasColumnName("FUN_NOME")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nome do funcionário");

        builder.Property(f => f.CPF)
            .HasColumnName("FUN_CPF")
            .HasColumnOrder(3)
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasComment("CPF do funcionário");

        builder.Property(f => f.Email)
            .HasColumnName("FUN_EMAIL")
            .HasColumnOrder(4)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Email do funcionário");

        builder.Property(f => f.Telefone)
            .HasColumnName("FUN_TELEFONE")
            .HasColumnOrder(5)
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasComment("Telefone do funcionário");

        builder.Property(f => f.Status)
            .HasColumnName("FUN_STATUS")
            .HasColumnOrder(6)
            .IsRequired()
            .HasComment("Status do funcionário");

        builder.Property(f => f.Cargo)
            .HasColumnName("FUN_CARGO")
            .HasColumnOrder(7)
            .IsRequired()
            .HasComment("Cargo do funcionário");

        builder.Property(f => f.DataAdmissao)
            .HasColumnName("FUN_DATA_ADMISSAO")
            .HasColumnOrder(8)
            .IsRequired()
            .HasColumnType("datetime")
            .HasComment("Data de admissão do funcionário");

        builder.Property(f => f.DataDemissao)
            .HasColumnName("FUN_DATA_DEMISSAO")
            .HasColumnOrder(9)
            .HasColumnType("datetime")
            .HasComment("Data de demissão do funcionário");

        builder.Property(f => f.DataCriacao)
            .HasColumnName("FUN_DATA_CRIACAO")
            .HasColumnOrder(10)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data de criação do funcionário");

        builder.Property(f => f.DataAtualizacao)
            .HasColumnName("FUN_DATA_ATUALIZACAO")
            .HasColumnOrder(11)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data da última atualização do funcionário");

        builder.Property(f => f.DataExclusao)
            .HasColumnName("FUN_DATA_EXCLUSAO")
            .HasColumnOrder(12)
            .HasColumnType("datetime")
            .HasComment("Data da exclusão do funcionário");

        builder.Property(f => f.CondominioId)
            .HasColumnName("FUN_CONDOMINIO_ID")
            .HasColumnOrder(13)
            .IsRequired()
            .HasComment("Chave estrangeira do condomínio");

        builder.HasOne(f => f.Condominio)
            .WithMany(c => c.Funcionarios)
            .HasForeignKey(f => f.CondominioId)
            .HasConstraintName("FK_FUNCIONARIO_CONDOMINIO")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(f => f.Entregas)
            .WithOne(u => u.Funcionario)
            .HasForeignKey(u => u.FuncionarioId)
            .HasConstraintName("FK_FUNCIONARIO_ENTREGA")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(f => f.CPF)
            .HasDatabaseName("IX_FUNCIONARIO_CPF")
            .IsUnique();

        builder.HasIndex(f => f.Email)
            .HasDatabaseName("IX_FUNCIONARIO_EMAIL")
            .IsUnique();
    }
}