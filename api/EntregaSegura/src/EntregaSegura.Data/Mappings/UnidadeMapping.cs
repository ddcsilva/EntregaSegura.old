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
            .HasComment("Chave primária da unidade");

        builder.Property(u => u.Numero)
            .HasColumnName("UND_NUMERO")
            .IsRequired()
            .HasColumnType("varchar(10)")
            .HasComment("Número da unidade");

        builder.Property(u => u.Bloco)
            .HasColumnName("UND_BLOCO")
            .HasColumnType("varchar(10)")
            .HasComment("Bloco da unidade");

        builder.Property(u => u.CondominioId)
            .HasColumnName("CON_ID")
            .HasComment("Chave estrangeira do condomínio");

        builder.Property(u => u.DataCriacao)
            .HasColumnName("UND_DATA_CRIACAO")
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data de criação da unidade");

        builder.Property(u => u.DataUltimaModificacao)
            .HasColumnName("UND_DATA_ULTIMA_MODIFICACAO")
            .IsRequired()
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data da última modificação da unidade");

        builder.Property(u => u.Excluido)
            .HasColumnName("UND_EXCLUIDO")
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
    }
}