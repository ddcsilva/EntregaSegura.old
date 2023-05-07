namespace EntregaSegura.Shared.DTOs;

/// <summary>
/// Classe que representa um DTO (Data Transfer Object) para criar um novo registro de Transportadora.
/// </summary>
public record TransportadoraCriacaoDTO(
    string Nome,
    string? CNPJ,
    string? Email,
    string? Telefone,
    int? Status
);