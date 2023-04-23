using EntregaSegura.Business.Models.Enums;

namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa uma entrega.
/// </summary>
public sealed class Entrega : BaseEntity
{
    /// <summary>
    /// Construtor padrão.
    /// </summary>
    public Entrega()
    {
        Remetente = string.Empty;
        Destinatario = string.Empty;
        DataRecebimento = DateTime.Now;
        Descricao = string.Empty;
        Observacao = string.Empty;
        Status = StatusEntrega.Recebida;        
    }

    public string Remetente { get; set; }
    public string Destinatario { get; set; }
    public DateTime DataRecebimento { get; set; }
    public DateTime? DataRetirada { get; set; }
    public string Descricao { get; set; }
    public string Observacao { get; set; }
    public StatusEntrega Status { get; set; }

    // Relacionamento 1:1 (Uma entrega pertence a uma transportadora)
    public Guid TransportadoraId { get; set; }
    public Transportadora Transportadora { get; set; }

    // Relacionamento 1:1 (Uma entrega pertence a uma unidade)
    public Guid UnidadeId { get; set; }
    public Unidade Unidade { get; set; }

    // Relacionamento 1:1 (Uma entrega só pode ser recebida por um funcionário)
    public Guid FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }
}