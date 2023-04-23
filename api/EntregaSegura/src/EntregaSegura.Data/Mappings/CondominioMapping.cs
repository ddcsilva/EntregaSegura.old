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
    /// Configura as propriedades da entidade <see cref="Condominio"/> para a tabela TB_CONDOMINIOS no banco de dados
    /// </summary>
    public void Configure(EntityTypeBuilder<Condominio> builder)
    {
        builder.ToTable("TB_CONDOMINIOS");
        
        builder.HasKey(c => c.Id)
            .HasName("PK_CND_ID");

        builder.Property(c => c.Id)
            .HasColumnName("CND_ID")
            .HasComment("Chave primária do condomínio");

        builder.Property(c => c.Nome)
            .HasColumnName("CND_NOME")
            .IsRequired()
            .HasComment("Nome do condomínio")
            .HasMaxLength(100);

        builder.Property(c => c.CNPJ)
            .HasColumnName("CND_CNPJ")
            .IsRequired()
            .HasComment("CNPJ do condomínio")
            .HasMaxLength(14);

        builder.Property(c => c.Telefone)
            .HasColumnName("CND_TELEFONE")
            .IsRequired()
            .HasComment("Telefone do condomínio")
            .HasMaxLength(11);

        builder.Property(c => c.Email)
            .HasColumnName("CND_EMAIL")
            .IsRequired()
            .HasComment("E-mail do condomínio")
            .HasMaxLength(100);

        // Relacionamento 1:1 (Um condomínio possui um endereço)
        builder.HasOne(c => c.Endereco)
            .WithOne(e => e.Condominio)
            .HasForeignKey<Endereco>(e => e.CondominioId)
            .HasConstraintName("FK_CONDOMINIO_ENDERECO")
            .OnDelete(DeleteBehavior.Cascade); // Se um condomínio for excluído, o endereço também será

        // Relacionamento 1:N (Um condomínio possui várias unidades)
        builder.HasMany(c => c.Unidades)
            .WithOne(u => u.Condominio)
            .HasForeignKey(u => u.CondominioId)
            .HasConstraintName("FK_CONDOMINIO_UNIDADE")
            .OnDelete(DeleteBehavior.Cascade); // Se um condomínio for excluído, as unidades também serão
    }
}