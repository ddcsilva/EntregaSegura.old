using EntregaSegura.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntregaSegura.Data.Mappings;

/// <summary>
/// Classe de mapeamento da entidade <see cref="Transportadora"/> para a tabela TB_TRANSPORTADORA no banco de dados
/// </summary>
public class TransportadoraMapping : IEntityTypeConfiguration<Transportadora>
{
    /// <summary>
    /// Configura as propriedades da entidade <see cref="Transportadora"/> para a tabela TB_TRANSPORTADORA no banco de dados
    /// </summary>
    public void Configure(EntityTypeBuilder<Transportadora> builder)
    {
        builder.ToTable("TB_TRANSPORTADORA");

        builder.HasKey(e => e.Id)
            .HasName("PK_TRA_ID");

        builder.Property(e => e.Id)
            .HasColumnName("TRA_ID")
            .HasComment("Chave primária da transportadora");

        builder.Property(e => e.Nome)
            .HasColumnName("TRA_NOME")
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nome da transportadora");

        builder.Property(e => e.CNPJ)
            .HasColumnName("TRA_CNPJ")
            .IsRequired()
            .HasColumnType("varchar(14)")
            .HasComment("CNPJ da transportadora");

        builder.Property(e => e.Telefone)
            .HasColumnName("TRA_TELEFONE")
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasComment("Telefone da transportadora");

        builder.Property(e => e.Email)
            .HasColumnName("TRA_EMAIL")
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("E-mail da transportadora");

        // Relacionamento 1:N (Uma transportadora possui várias entregas) e N:1 (Uma entrega pertence a uma transportadora)
        builder.HasMany(t => t.Entregas)
            .WithOne(e => e.Transportadora)
            .HasForeignKey(e => e.TransportadoraId)
            .HasConstraintName("FK_ENTREGA_TRANSPORTADORA")
            .OnDelete(DeleteBehavior.Cascade); // Se uma transportadora for excluída, as entregas também serão
    }
}