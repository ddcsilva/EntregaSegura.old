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
    /// Método que configura as propriedades da entidade <see cref="Endereco"/> para a tabela TB_ENDERECOS no banco de dados
    /// </summary>
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("TB_ENDERECOS");

        builder.HasKey(e => e.Id)
            .HasName("PK_ENDERECOS");

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

        builder.Property(e => e.DataCriacao)
            .HasColumnName("END_DATA_CRIACAO")
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data de criação do endereço");

        builder.Property(e => e.DataUltimaModificacao)
            .HasColumnName("END_DATA_ULTIMA_MODIFICACAO")
            .HasColumnType("datetime")
            .HasComment("Data da última modificação do endereço");

        builder.Property(e => e.CondominioId)
            .HasColumnName("CON_ID")
            .IsRequired()
            .HasComment("Chave estrangeira do condomínio");

        builder.Property(e => e.Excluido)
            .HasColumnName("END_EXCLUIDO")
            .IsRequired()
            .HasColumnType("bit")
            .HasDefaultValue(false)
            .HasComment("Flag que indica se o endereço foi excluído");

        // Um endereço pertence a um condomínio e um condomínio possui um endereço
        builder.HasOne(e => e.Condominio)
            .WithOne(c => c.Endereco)
            .HasForeignKey<Endereco>(e => e.CondominioId)
            .HasConstraintName("FK_ENDERECO_CONDOMINIO")
            .OnDelete(DeleteBehavior.Restrict);
    }
}