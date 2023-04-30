using EntregaSegura.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntregaSegura.Data.Mappings;

/// <summary>
/// Classe de mapeamento da entidade <see cref="Unidade"/> para a tabela TB_UNIDADES no banco de dados
/// </summary>
public class UnidadeMapping : IEntityTypeConfiguration<Unidade>
{
    /// <summary>
    /// Método que configura as propriedades da entidade <see cref="Unidade"/> para a tabela TB_UNIDADES no banco de dados
    /// </summary>
    public void Configure(EntityTypeBuilder<Unidade> builder)
    {
        builder.ToTable("TB_UNIDADES");

        builder.HasKey(u => u.Id)
            .HasName("PK_UNIDADES");

        builder.Property(u => u.Id)
            .HasColumnName("UND_ID")
            .HasColumnOrder(1)
            .HasComment("Chave primária da unidade");

        builder.Property(u => u.CondominioId)
            .HasColumnName("CON_ID")
            .HasColumnOrder(2)
            .HasComment("Chave estrangeira do condomínio");

        builder.Property(u => u.Numero)
            .HasColumnName("UND_NUMERO")
            .HasColumnOrder(3)
            .IsRequired()
            .HasColumnType("varchar(10)")
            .HasComment("Número da unidade");

        builder.Property(u => u.Bloco)
            .HasColumnName("UND_BLOCO")
            .HasColumnOrder(4)
            .HasColumnType("varchar(10)")
            .HasComment("Bloco da unidade");

        builder.Property(u => u.DataCriacao)
            .HasColumnName("UND_DATA_CRIACAO")
            .HasColumnOrder(5)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data de criação da unidade");

        builder.Property(u => u.DataUltimaModificacao)
            .HasColumnName("UND_DATA_ULTIMA_MODIFICACAO")
            .HasColumnOrder(6)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data da última modificação da unidade");

        builder.Property(u => u.Excluido)
            .HasColumnName("UND_EXCLUIDO")
            .HasColumnOrder(7)
            .IsRequired()
            .HasDefaultValue(false)
            .HasComment("Flag que indica se a unidade foi excluída");

        builder.HasOne(u => u.Condominio)
            .WithMany(c => c.Unidades)
            .HasForeignKey(u => u.CondominioId)
            .HasConstraintName("FK_UNIDADES_CONDOMINIOS")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Entregas)
            .WithOne(e => e.Unidade)
            .HasForeignKey(e => e.UnidadeId)
            .HasConstraintName("FK_ENTREGAS_UNIDADES")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Moradores)
            .WithOne(m => m.Unidade)
            .HasForeignKey(m => m.UnidadeId)
            .HasConstraintName("FK_MORADORES_UNIDADES")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(u => new { u.CondominioId, u.Numero, u.Bloco })
            .HasDatabaseName("IX_UNIDADES_CONDOMINIO_NUMERO_BLOCO")
            .IsUnique();
    }
}