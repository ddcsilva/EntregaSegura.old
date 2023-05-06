using EntregaSegura.Entities.Models.Enums;

namespace EntregaSegura.Entities.Models;

/// <summary>
/// Classe que representa uma entrega.
/// </summary>
public sealed class Entrega : BaseEntity
{
    public Entrega()
    {
        DataRecebimento = DateTime.Now;
        Status = StatusEntrega.Recebida;        
    }

    public string? Remetente { get; set; }
    public string? Destinatario { get; set; }
    public DateTime DataRecebimento { get; set; }
    public DateTime? DataRetirada { get; set; }
    public string? Descricao { get; set; }
    public string? Observacao { get; set; }
    public StatusEntrega Status { get; set; }

    // Uma entrega pertence a apenas uma transportadora
    public Guid TransportadoraId { get; set; }
    public Transportadora? Transportadora { get; set; }

    // Uma entrega pertence a apenas um morador
    public Guid MoradorId { get; set; }
    public Morador? Morador { get; set; }

    // Uma entrega só pode ser manipulada por um funcionário
    public Guid FuncionarioId { get; set; }
    public Funcionario? Funcionario { get; set; }
}