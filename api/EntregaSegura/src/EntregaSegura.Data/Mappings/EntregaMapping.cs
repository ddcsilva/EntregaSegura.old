using EntregaSegura.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntregaSegura.Data.Mappings;

/// <summary>
/// Classe de mapeamento da entidade <see cref="Entrega"/> para a tabela TB_ENTREGAS
/// </summary>
public class EntregaMapping : IEntityTypeConfiguration<Entrega>
{
    /// <summary>
    /// Método que configura as propriedades da entidade <see cref="Entrega"/> para a tabela TB_ENTREGAS no banco de dados
    /// </summary>
    public void Configure(EntityTypeBuilder<Entrega> builder)
    {
        builder.ToTable("TB_ENTREGAS");
        
        builder.HasKey(e => e.Id)
            .HasName("PK_ETG_ID");

        builder.Property(e => e.Id)
            .HasColumnName("ETG_ID")
            .HasComment("Chave primária da entrega");

        builder.Property(e => e.Remetente)
            .HasColumnName("ETG_REMETENTE")
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nome do remetente da entrega");

        builder.Property(e => e.Destinatario)
            .HasColumnName("ETG_DESTINATARIO")
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nome do destinatário da entrega");

        builder.Property(e => e.DataRecebimento)
            .HasColumnName("ETG_DATA_RECEBIMENTO")
            .HasColumnType("datetime")
            .IsRequired()
            .HasComment("Data de recebimento da entrega");

        builder.Property(e => e.DataRetirada)
            .HasColumnName("ETG_DATA_RETIRADA")
            .HasColumnType("datetime")
            .HasComment("Data de retirada da entrega");

        builder.Property(e => e.Status)
            .HasColumnName("ETG_STATUS")
            .IsRequired()
            .HasColumnType("char(1)")
            .HasComment("Status da entrega");

        // Relacionamento 1:1 (Uma entrega pertence a uma transportadora) e 1:N (Uma transportadora pode ter várias entregas)
        builder.HasOne(e => e.Transportadora)
            .WithMany(t => t.Entregas)
            .HasForeignKey(e => e.TransportadoraId)
            .HasConstraintName("FK_ENTREGA_TRANSPORTADORA")
            .OnDelete(DeleteBehavior.Cascade); // Se uma entrega for excluída, a transportadora também será

        // Relacionamento 1:1 (Uma entrega pertence a uma unidade) e 1:N (Uma unidade pode ter várias entregas)
        builder.HasOne(e => e.Unidade)
            .WithMany(u => u.Entregas)
            .HasForeignKey(e => e.UnidadeId)
            .HasConstraintName("FK_ENTREGA_UNIDADE")
            .OnDelete(DeleteBehavior.Cascade); // Se uma entrega for excluída, a unidade também será

        // Relacionamento 1:1 (Uma entrega só pode ser recebida por um funcionário) e 1:N (Um funcionário pode receber várias entregas)
        builder.HasOne(e => e.Funcionario)
            .WithMany(f => f.Entregas)
            .HasForeignKey(e => e.FuncionarioId)
            .HasConstraintName("FK_ENTREGA_FUNCIONARIO")
            .OnDelete(DeleteBehavior.Cascade); // Se uma entrega for excluída, o funcionário também será
    }
}
