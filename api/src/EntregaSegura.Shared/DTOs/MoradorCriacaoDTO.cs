namespace EntregaSegura.Shared.DTOs;

/// <summary>
/// Classe que representa um DTO (Data Transfer Object) para criar um novo registro de Morador.
/// </summary>
public record MoradorCriacaoDTO(
    string Nome,
    string CPF,
    string Email,
    string Telefone,
    int? Status
);