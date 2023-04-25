using EntregaSegura.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntregaSegura.Data.Mappings;

/// <summary>
/// Classe de mapeamento da entidade <see cref="Condominio"/> para a tabela TB_CONDOMINIOS no banco de dados
/// </summary>
public class CondominioMapping : IEntityTypeConfiguration<Condominio>
{
    /// <summary>
    /// Método que configura as propriedades da entidade <see cref="Condominio"/> para a tabela TB_CONDOMINIOS no banco de dados
    /// </summary>
    public void Configure(EntityTypeBuilder<Condominio> builder)
    {
        builder.ToTable("TB_CONDOMINIOS");
        
        builder.HasKey(c => c.Id)
            .HasName("PK_CONDOMINIOS");

        builder.Property(c => c.Id)
            .HasColumnName("CND_ID")
            .HasComment("Chave primária do condomínio");

        builder.Property(c => c.Nome)
            .HasColumnName("CND_NOME")
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nome do condomínio");

        builder.Property(c => c.CNPJ)
            .HasColumnName("CND_CNPJ")
            .IsRequired()
            .HasColumnType("varchar(14)")
            .HasComment("CNPJ do condomínio");;

        builder.Property(c => c.Telefone)
            .HasColumnName("CND_TELEFONE")
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasComment("Telefone do condomínio");

        builder.Property(c => c.Email)
            .HasColumnName("CND_EMAIL")
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("E-mail do condomínio");

        builder.Property(c => c.DataCriacao)
            .HasColumnName("CND_DATA_CRIACAO")
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data de criação do condomínio");

        builder.Property(c => c.DataUltimaModificacao)
            .HasColumnName("CND_DATA_ULTIMA_MODIFICACAO")
            .HasColumnType("datetime")
            .HasComment("Data da última modificação do condomínio");

        builder.Property(c => c.Excluido)
            .HasColumnName("CND_EXCLUIDO")
            .IsRequired()
            .HasColumnType("bit")
            .HasDefaultValue(false)
            .HasComment("Flag que indica se o condomínio foi excluído");

        // Um condomínio possui um endereço e um endereço pertence a um condomínio
        builder.HasOne(c => c.Endereco)
            .WithOne(e => e.Condominio)
            .HasForeignKey<Endereco>(e => e.CondominioId)
            .HasConstraintName("FK_CONDOMINIO_ENDERECO")
            .OnDelete(DeleteBehavior.Restrict);

        // Um condomínio possui várias unidades e uma unidade pertence a um condomínio
        builder.HasMany(c => c.Unidades)
            .WithOne(u => u.Condominio)
            .HasForeignKey(u => u.CondominioId)
            .HasConstraintName("FK_CONDOMINIO_UNIDADE")
            .OnDelete(DeleteBehavior.Restrict);
    }
}