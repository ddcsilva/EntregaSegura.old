using EntregaSegura.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntregaSegura.Repository.Configurations;

public class CondominioConfiguration : IEntityTypeConfiguration<Condominio>
{
    public void Configure(EntityTypeBuilder<Condominio> builder)
    {
        builder.ToTable("TB_CONDOMINIOS");

        builder.HasKey(c => c.Id)
            .HasName("PK_CONDOMINIOS");

        builder.Property(c => c.Id)
            .HasColumnName("CND_ID")
            .HasColumnOrder(1)
            .HasComment("Chave primária do condomínio");

        builder.Property(c => c.Nome)
            .HasColumnName("CND_NOME")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nome do condomínio");

        builder.Property(c => c.CNPJ)
            .HasColumnName("CND_CNPJ")
            .HasColumnOrder(3)
            .IsRequired()
            .HasColumnType("varchar(14)")
            .HasComment("CNPJ do condomínio"); ;

        builder.Property(c => c.Telefone)
            .HasColumnName("CND_TELEFONE")
            .HasColumnOrder(4)
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasComment("Telefone do condomínio");

        builder.Property(c => c.Email)
            .HasColumnName("CND_EMAIL")
            .HasColumnOrder(5)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("E-mail do condomínio");

        builder.Property(c => c.DataCriacao)
            .HasColumnName("CND_DATA_CRIACAO")
            .HasColumnOrder(6)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data de criação do condomínio");

        builder.Property(c => c.DataAtualizacao)
            .HasColumnName("CND_DATA_ATUALIZACAO")
            .HasColumnOrder(7)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data da última atualização do condomínio");

        builder.Property(c => c.DataExclusao)
            .HasColumnName("CND_DATA_EXCLUSAO")
            .HasColumnOrder(8)
            .HasColumnType("datetime")
            .HasComment("Data da exclusão do condomínio");

        // Um condomínio possui um endereço e um endereço pertence a um condomínio
        builder.HasOne(c => c.Endereco)
            .WithOne(e => e.Condominio)
            .HasForeignKey<Endereco>(e => e.CondominioId)
            .HasConstraintName("FK_CONDOMINIO_ENDERECO")
            .OnDelete(DeleteBehavior.Cascade);

        // Um condomínio possui várias unidades e uma unidade pertence a um condomínio
        builder.HasMany(c => c.Unidades)
            .WithOne(u => u.Condominio)
            .HasForeignKey(u => u.CondominioId)
            .HasConstraintName("FK_CONDOMINIO_UNIDADE")
            .OnDelete(DeleteBehavior.Restrict);

        // Um condomínio possui vários funcionários e um funcionário pertence a um condomínio
        builder.HasMany(c => c.Funcionarios)
            .WithOne(f => f.Condominio)
            .HasForeignKey(f => f.CondominioId)
            .HasConstraintName("FK_CONDOMINIO_FUNCIONARIO")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(c => c.CNPJ)
            .HasDatabaseName("IX_CONDOMINIOS_CNPJ")
            .IsUnique();

        builder.HasIndex(c => c.Email)
            .HasDatabaseName("IX_CONDOMINIOS_EMAIL")
            .IsUnique();

        builder.HasIndex(c => c.Nome)
            .HasDatabaseName("IX_CONDOMINIOS_NOME")
            .IsUnique();
    }
}
