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
    /// Método que configura as propriedades da entidade <see cref="Transportadora"/> para a tabela TB_TRANSPORTADORAS no banco de dados
    /// </summary>
    public void Configure(EntityTypeBuilder<Transportadora> builder)
    {
        builder.ToTable("TB_TRANSPORTADORAS");

        builder.HasKey(e => e.Id)
            .HasName("PK_TRANSPORTADORAS");

        builder.Property(e => e.Id)
            .HasColumnName("TRA_ID")
            .HasColumnOrder(1)
            .HasComment("Chave primária da transportadora");

        builder.Property(e => e.Nome)
            .HasColumnName("TRA_NOME")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nome da transportadora");

        builder.Property(e => e.CNPJ)
            .HasColumnName("TRA_CNPJ")
            .HasColumnOrder(3)
            .IsRequired()
            .HasColumnType("varchar(14)")
            .HasComment("CNPJ da transportadora");

        builder.Property(e => e.Telefone)
            .HasColumnName("TRA_TELEFONE")
            .HasColumnOrder(4)
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasComment("Telefone da transportadora");

        builder.Property(e => e.Email)
            .HasColumnName("TRA_EMAIL")
            .HasColumnOrder(5)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("E-mail da transportadora");

        builder.Property(e => e.DataCriacao)
            .HasColumnName("TRA_DATA_CRIACAO")
            .HasColumnOrder(6)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data de criação da transportadora");

        builder.Property(e => e.DataUltimaModificacao)
            .HasColumnName("TRA_DATA_ULTIMA_MODIFICACAO")
            .HasColumnOrder(7)
            .HasColumnType("datetime")
            .HasComment("Data da última modificação da transportadora");

        builder.Property(e => e.Excluido)
            .HasColumnName("TRA_EXCLUIDO")
            .HasColumnOrder(8)
            .IsRequired()
            .HasColumnType("bit")
            .HasDefaultValueSql("0")
            .HasComment("Flag de exclusão da transportadora");

        // Uma transportadora possui várias entregas e uma entrega possui uma transportadora
        builder.HasMany(t => t.Entregas)
            .WithOne(e => e.Transportadora)
            .HasForeignKey(e => e.TransportadoraId)
            .HasConstraintName("FK_ENTREGA_TRANSPORTADORA")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.CNPJ)
            .HasDatabaseName("IX_TRANSPORTADORAS_CNPJ")
            .IsUnique();

        builder.HasIndex(e => e.Email)
            .HasDatabaseName("IX_TRANSPORTADORAS_EMAIL")
            .IsUnique();

        builder.HasIndex(e => e.Nome)
            .HasDatabaseName("IX_TRANSPORTADORAS_NOME")
            .IsUnique();
    }
}