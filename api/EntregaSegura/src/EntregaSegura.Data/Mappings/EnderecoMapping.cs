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
            .HasColumnType("varchar(100)")
            .HasComment("Logradouro do endereço");

        builder.Property(e => e.Numero)
            .HasColumnName("END_NUMERO")
            .IsRequired()
            .HasColumnType("varchar(10)")
            .HasComment("Número do endereço");

        builder.Property(e => e.Complemento)
            .HasColumnName("END_COMPLEMENTO")
            .HasColumnType("varchar(100)")
            .HasComment("Complemento do endereço");

        builder.Property(e => e.CEP)
            .HasColumnName("END_CEP")
            .IsRequired()
            .HasColumnType("varchar(8)")
            .HasComment("CEP do endereço");

        builder.Property(e => e.Bairro)
            .HasColumnName("END_BAIRRO")
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasComment("Bairro do endereço");

        builder.Property(e => e.Cidade)
            .HasColumnName("END_CIDADE")
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasComment("Cidade do endereço");

        builder.Property(e => e.Estado)
            .HasColumnName("END_ESTADO")
            .IsRequired()
            .HasColumnType("varchar(2)")
            .HasComment("Estado do endereço");

        // Relacionamento 1:1 (Um endereço pertence a um condomínio) e 1:1 (Um condomínio só pode ter um endereço)
        builder.HasOne(e => e.Condominio)
            .WithOne(c => c.Endereco)
            .HasForeignKey<Endereco>(e => e.CondominioId)
            .HasConstraintName("FK_ENDERECO_CONDOMINIO")
            .OnDelete(DeleteBehavior.Cascade); // Se um endereço for excluído, o condomínio também será
    }
}