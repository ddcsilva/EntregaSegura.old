namespace EntregaSegura.Shared.DTOs;

/// <summary>
/// Classe que representa um DTO (Data Transfer Object) para criar um novo registro de Entrega.
/// </summary>
public record EntregaCriacaoDTO(
    string? Descricao,
    string? Observacao,
    Guid TransportadoraId,
    Guid MoradorId
);