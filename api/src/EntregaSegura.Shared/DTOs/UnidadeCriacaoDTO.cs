namespace EntregaSegura.Shared.DTOs;

/// <summary>
/// Classe que representa um DTO (Data Transfer Object) para criar um novo registro de Unidade.
/// </summary>
public record UnidadeCriacaoDTO(
    string Numero,
    string Bloco
);