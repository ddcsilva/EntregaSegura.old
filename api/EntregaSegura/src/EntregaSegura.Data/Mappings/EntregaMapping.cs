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
            .HasName("PK_ENTREGAS");

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

        builder.Property(e => e.Descricao)
            .HasColumnName("ETG_DESCRICAO")
            .HasColumnType("varchar(200)")
            .HasComment("Descrição da entrega");

        builder.Property(e => e.Observacao)
            .HasColumnName("ETG_OBSERVACAO")
            .HasColumnType("varchar(200)")
            .HasComment("Observação da entrega");

        builder.Property(e => e.Status)
            .HasColumnName("ETG_STATUS")
            .IsRequired()
            .HasColumnType("char(1)")
            .HasComment("Status da entrega");

        builder.Property(e => e.DataCriacao)
            .HasColumnName("ETG_DATA_CRIACAO")
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .HasComment("Data de criação da entrega");

        builder.Property(e => e.DataUltimaModificacao)
            .HasColumnName("ETG_DATA_ULTIMA_MODIFICACAO")
            .HasColumnType("datetime")
            .HasComment("Data da última modificação da entrega");

        builder.Property(e => e.Excluido)
            .HasColumnName("ETG_EXCLUIDO")
            .IsRequired()
            .HasColumnType("bit")
            .HasDefaultValue(false)
            .HasComment("Flag de exclusão da entrega");

        builder.Property(e => e.TransportadoraId)
            .HasColumnName("TRP_ID")
            .IsRequired()
            .HasComment("Chave estrangeira da transportadora");

        builder.Property(e => e.UnidadeId)
            .HasColumnName("UND_ID")
            .IsRequired()
            .HasComment("Chave estrangeira da unidade");

        builder.Property(e => e.FuncionarioId)
            .HasColumnName("FUN_ID")
            .IsRequired()
            .HasComment("Chave estrangeira do funcionário");

        builder.Property(e => e.MoradorId)
            .HasColumnName("MOR_ID")
            .IsRequired()
            .HasComment("Chave estrangeira do morador");

        // Uma entrega pertence a apenas uma transportadora e uma transportadora pode ter várias entregas
        builder.HasOne(e => e.Transportadora)
            .WithMany(t => t.Entregas)
            .HasForeignKey(e => e.TransportadoraId)
            .HasConstraintName("FK_ENTREGA_TRANSPORTADORA")
            .OnDelete(DeleteBehavior.Restrict);

        // Uma entrega pertence a apenas uma unidade e uma unidade pode ter várias entregas
        builder.HasOne(e => e.Unidade)
            .WithMany(u => u.Entregas)
            .HasForeignKey(e => e.UnidadeId)
            .HasConstraintName("FK_ENTREGA_UNIDADE")
            .OnDelete(DeleteBehavior.Restrict);

        // Uma entrega pertence a apenas um morador e um morador pode ter várias entregas
        builder.HasOne(e => e.Morador)
            .WithMany(m => m.Entregas)
            .HasForeignKey(e => e.MoradorId)
            .HasConstraintName("FK_ENTREGA_MORADOR")
            .OnDelete(DeleteBehavior.Restrict);

        // Uma entrega só pode ser manipulada por um funcionário e um funcionário pode manipular várias entregas
        builder.HasOne(e => e.Funcionario)
            .WithMany(f => f.Entregas)
            .HasForeignKey(e => e.FuncionarioId)
            .HasConstraintName("FK_ENTREGA_FUNCIONARIO")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
