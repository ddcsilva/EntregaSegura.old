using EntregaSegura.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntregaSegura.Data.Mappings;

/// <summary>
/// Classe de mapeamento da entidade <see cref="Morador"/> para a tabela TB_MORADORES no banco de dados
/// </summary>
public class MoradorMapping : IEntityTypeConfiguration<Morador>
{
    /// <summary>
    /// Método que configura as propriedades da entidade <see cref="Morador"/> para a tabela TB_MORADORES no banco de dados
    /// </summary>
    public void Configure(EntityTypeBuilder<Morador> builder)
    {
        builder.ToTable("TB_MORADORES");

        builder.HasKey(m => m.Id)
            .HasName("PK_MORADORES");

        builder.Property(m => m.Id)
            .HasColumnName("MOR_ID")
            .HasComment("Chave primária do morador");

        builder.Property(m => m.Nome)
            .HasColumnName("MOR_NOME")
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nome do morador");

        builder.Property(m => m.CPF)
            .HasColumnName("MOR_CPF")
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasComment("CPF do morador");

        builder.Property(m => m.Status)
            .HasColumnName("MOR_STATUS")
            .IsRequired()
            .HasComment("Status do morador");

        builder.Property(m => m.UnidadeId)
            .HasColumnName("MOR_UNIDADE_ID")
            .IsRequired()
            .HasComment("Chave estrangeira da unidade do morador");

        builder.Property(m => m.DataCriacao)
            .HasColumnName("MOR_DATA_CRIACAO")
            .IsRequired()
            .HasColumnType("datetime")
            .HasComment("Data de criação do morador");

        builder.Property(m => m.DataUltimaModificacao)
            .HasColumnName("MOR_DATA_ULTIMA_MODIFICACAO")
            .HasColumnType("datetime")
            .HasComment("Data da última modificação do morador");

        builder.Property(m => m.Excluido)
            .HasColumnName("MOR_EXCLUIDO")
            .IsRequired()
            .HasDefaultValue(false)
            .HasComment("Flag que indica se o morador foi excluído");

        builder.HasOne(m => m.Unidade)
            .WithMany(u => u.Moradores)
            .HasForeignKey(m => m.UnidadeId)
            .HasConstraintName("FK_MORADORES_UNIDADES")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(m => m.Entregas)
            .WithOne(e => e.Morador)
            .HasForeignKey(e => e.MoradorId)
            .HasConstraintName("FK_MORADORES_ENTREGAS")
            .OnDelete(DeleteBehavior.Restrict);
    }
}