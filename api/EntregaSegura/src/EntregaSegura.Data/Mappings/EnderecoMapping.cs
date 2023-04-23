using EntregaSegura.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntregaSegura.Data.Mappings;

/// <summary>
/// Classe de mapeamento da entidade <see cref="Endereco"/> para a tabela TB_ENDERECOS no banco de dados
/// </summary>
public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
{
    /// <summary>
    /// Configura as propriedades da entidade <see cref="Endereco"/> para a tabela TB_ENDERECOS no banco de dados
    /// </summary>
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("TB_ENDERECOS");
        
        builder.HasKey(e => e.Id)
            .HasName("PK_END_ID");

        builder.Property(e => e.Id)
            .HasColumnName("END_ID")
            .HasComment("Chave primária do endereço");

        builder.Property(e => e.Logradouro)
            .HasColumnName("END_LOGRADOURO")
            .IsRequired()
            .HasComment("Logradouro do endereço")
            .HasMaxLength(100);

        builder.Property(e => e.Numero)
            .HasColumnName("END_NUMERO")
            .IsRequired()
            .HasComment("Número do endereço")
            .HasMaxLength(10);

        builder.Property(e => e.Complemento)
            .HasColumnName("END_COMPLEMENTO")
            .HasComment("Complemento do endereço")
            .HasMaxLength(100);

        builder.Property(e => e.CEP)
            .HasColumnName("END_CEP")
            .IsRequired()
            .HasComment("CEP do endereço")
            .HasMaxLength(8);

        builder.Property(e => e.Bairro)
            .HasColumnName("END_BAIRRO")
            .IsRequired()
            .HasComment("Bairro do endereço")
            .HasMaxLength(100);

        builder.Property(e => e.Cidade)
            .HasColumnName("END_CIDADE")
            .IsRequired()
            .HasComment("Cidade do endereço")
            .HasMaxLength(50);

        builder.Property(e => e.Estado)
            .HasColumnName("END_ESTADO")
            .IsRequired()
            .HasComment("Estado do endereço")
            .HasMaxLength(2);

        // Relacionamento 1:1 (Um endereço pertence a um condomínio) e 1:1 (Um condomínio só pode ter um endereço)
        builder.HasOne(e => e.Condominio)
            .WithOne(c => c.Endereco)
            .HasForeignKey<Endereco>(e => e.CondominioId)
            .HasConstraintName("FK_ENDERECO_CONDOMINIO")
            .OnDelete(DeleteBehavior.Cascade); // Se um endereço for excluído, o condomínio também será
    }
}