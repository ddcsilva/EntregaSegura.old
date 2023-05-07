namespace EntregaSegura.Shared.DTOs;

/// <summary>
/// Classe que representa um DTO (Data Transfer Object) para representar um registro de Entrega.
/// </summary>
public record EntregaDTO(
    Guid Id, 
    DateTime DataRecebimento, 
    DateTime? DataRetirada, 
    string Descricao, 
    string Observacao, 
    int Status, 
    Guid TransportadoraId, 
    Guid MoradorId, 
    Guid FuncionarioId
);
