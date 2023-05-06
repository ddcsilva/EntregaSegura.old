using EntregaSegura.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntregaSegura.Repository.Configurations;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("TB_ENDERECOS");

        builder.HasKey(e => e.Id)
            .HasName("PK_ENDERECOS");

        builder.Property(e => e.Id)
            .HasColumnName("END_ID")
            .HasColumnOrder(1)
            .HasComment("Chave primária do endereço");

        builder.Property(e => e.CondominioId)
            .HasColumnName("CON_ID")
            .HasColumnOrder(2)
            .IsRequired()
            .HasComment("Chave estrangeira do condomínio");

        builder.Property(e => e.Logradouro)
            .HasColumnName("END_LOGRADOURO")
            .HasColumnOrder(3)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Logradouro do endereço");

        builder.Property(e => e.Numero)
            .HasColumnName("END_NUMERO")
            .HasColumnOrder(4)
            .IsRequired()
            .HasColumnType("varchar(10)")
            .HasComment("Número do endereço");

        builder.Property(e => e.Complemento)
            .HasColumnName("END_COMPLEMENTO")
            .HasColumnOrder(5)
            .HasColumnType("varchar(100)")
            .HasComment("Complemento do endereço");

        builder.Property(e => e.CEP)
            .HasColumnName("END_CEP")
            .HasColumnOrder(6)
            .IsRequired()
            .HasColumnType("varchar(8)")
            .HasComment("CEP do endereço");

        builder.Property(e => e.Bairro)
            .HasColumnName("END_BAIRRO")
            .HasColumnOrder(7)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasComment("Bairro do endereço");

        builder.Property(e => e.Cidade)
            .HasColumnName("END_CIDADE")
            .HasColumnOrder(8)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasComment("Cidade do endereço");

        builder.Property(e => e.Estado)
            .HasColumnName("END_ESTADO")
            .HasColumnOrder(9)
            .IsRequired()
            .HasColumnType("varchar(2)")
            .HasComment("Estado do endereço");

        builder.Property(e => e.DataCriacao)
            .HasColumnName("END_DATA_CRIACAO")
            .HasColumnOrder(10)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data de criação do endereço");

        builder.Property(e => e.DataUltimaModificacao)
            .HasColumnName("END_DATA_ULTIMA_MODIFICACAO")
            .HasColumnOrder(11)
            .HasColumnType("datetime")
            .HasComment("Data da última modificação do endereço");

        builder.Property(e => e.Excluido)
            .HasColumnName("END_EXCLUIDO")
            .HasColumnOrder(12)
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

        builder.HasIndex(e => e.CondominioId)
            .HasDatabaseName("IX_ENDERECO_CONDOMINIO");

        builder.HasIndex(e => e.CEP)
            .HasDatabaseName("IX_ENDERECO_CEP");
    }
}