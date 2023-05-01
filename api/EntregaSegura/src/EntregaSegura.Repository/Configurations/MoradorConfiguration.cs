using EntregaSegura.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntregaSegura.Repository.Configurations;

public class MoradorConfiguration : IEntityTypeConfiguration<Morador>
{
    public void Configure(EntityTypeBuilder<Morador> builder)
    {
        builder.ToTable("TB_MORADORES");

        builder.HasKey(m => m.Id)
            .HasName("PK_MORADORES");

        builder.Property(m => m.Id)
            .HasColumnName("MOR_ID")
            .HasColumnOrder(1)
            .HasComment("Chave primária do morador");

        builder.Property(m => m.Nome)
            .HasColumnName("MOR_NOME")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nome do morador");

        builder.Property(m => m.CPF)
            .HasColumnName("MOR_CPF")
            .HasColumnOrder(3)
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasComment("CPF do morador");

        builder.Property(m => m.Status)
            .HasColumnName("MOR_STATUS")
            .HasColumnOrder(4)
            .IsRequired()
            .HasComment("Status do morador");

        builder.Property(m => m.UnidadeId)
            .HasColumnName("MOR_UNIDADE_ID")
            .HasColumnOrder(5)
            .IsRequired()
            .HasComment("Chave estrangeira da unidade do morador");

        builder.Property(m => m.DataCriacao)
            .HasColumnName("MOR_DATA_CRIACAO")
            .HasColumnOrder(6)
            .IsRequired()
            .HasColumnType("datetime")
            .HasComment("Data de criação do morador");

        builder.Property(m => m.DataUltimaModificacao)
            .HasColumnName("MOR_DATA_ULTIMA_MODIFICACAO")
            .HasColumnOrder(7)
            .HasColumnType("datetime")
            .HasComment("Data da última modificação do morador");

        builder.Property(m => m.Excluido)
            .HasColumnName("MOR_EXCLUIDO")
            .HasColumnOrder(8)
            .IsRequired()
            .HasDefaultValue(false)
            .HasComment("Flag que indica se o morador foi excluído");

        builder.HasOne(m => m.Unidade)
            .WithMany(u => u.Moradores)
            .HasForeignKey(m => m.UnidadeId)
            .HasConstraintName("FK_MORADORES_UNIDADES")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(m => m.Entregas)
            .WithOne(e => e.Morador)
            .HasForeignKey(e => e.MoradorId)
            .HasConstraintName("FK_MORADORES_ENTREGAS")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(m => m.CPF)
            .HasDatabaseName("IX_MORADORES_CPF")
            .IsUnique();

        builder.HasIndex(m => m.UnidadeId)
            .HasDatabaseName("IX_MORADORES_UNIDADE_ID");
    }
}