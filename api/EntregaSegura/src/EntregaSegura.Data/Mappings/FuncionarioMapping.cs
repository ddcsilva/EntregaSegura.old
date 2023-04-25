using EntregaSegura.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntregaSegura.Data.Mappings;

/// <summary>
/// Classe de mapeamento da entidade <see cref="Funcionario"/> para a tabela TB_FUNCIONARIOS no banco de dados
/// </summary>
public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
{
    /// <summary>
    /// Método que configura as propriedades da entidade <see cref="Funcionario"/> para a tabela TB_FUNCIONARIOS no banco de dados
    /// </summary>
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("TB_FUNCIONARIOS");

        builder.HasKey(f => f.Id)
            .HasName("PK_FUNCIONARIOS");

        builder.Property(f => f.Id)
            .HasColumnName("FUN_ID")
            .HasComment("Chave primária do funcionário");

        builder.Property(f => f.Nome)
            .HasColumnName("FUN_NOME")
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nome do funcionário");

        builder.Property(f => f.CPF)
            .HasColumnName("FUN_CPF")
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasComment("CPF do funcionário");

        builder.Property(f => f.Status)
            .HasColumnName("FUN_STATUS")
            .IsRequired()
            .HasComment("Status do funcionário");

        builder.Property(f => f.Cargo)
            .HasColumnName("FUN_CARGO")
            .IsRequired()
            .HasComment("Cargo do funcionário");

        builder.Property(f => f.DataAdmissao)
            .HasColumnName("FUN_DATA_ADMISSAO")
            .IsRequired()
            .HasColumnType("datetime")
            .HasComment("Data de admissão do funcionário");

        builder.Property(f => f.DataDemissao)
            .HasColumnName("FUN_DATA_DEMISSAO")
            .HasColumnType("datetime")
            .HasComment("Data de demissão do funcionário");

        builder.Property(f => f.DataCriacao)
            .HasColumnName("FUN_DATA_CRIACAO")
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data de criação do funcionário");

        builder.Property(f => f.DataUltimaModificacao)
            .HasColumnName("FUN_DATA_ULTIMA_MODIFICACAO")
            .HasColumnType("datetime")
            .HasComment("Data da última modificação do funcionário");

        builder.Property(f => f.Excluido)
            .HasColumnName("FUN_EXCLUIDO")
            .IsRequired()
            .HasColumnType("bit")
            .HasDefaultValue(false)
            .HasComment("Flag que indica se o funcionário foi excluído");

        builder.HasMany(f => f.Entregas)
            .WithOne(u => u.Funcionario)
            .HasForeignKey(u => u.FuncionarioId)
            .HasConstraintName("FK_FUNCIONARIO_ENTREGA")
            .OnDelete(DeleteBehavior.Restrict);
    }
}