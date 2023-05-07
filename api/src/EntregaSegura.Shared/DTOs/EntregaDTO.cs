namespace EntregaSegura.Shared.DTOs;

public record EntregaDTO(
    Guid Id, 
    string Destinatario, 
    DateTime DataRecebimento, 
    DateTime? DataRetirada, 
    string Descricao, 
    string Observacao, 
    int Status, 
    Guid TransportadoraId, 
    Guid UnidadeId, 
    Guid MoradorId, 
    Guid FuncionarioId
);
