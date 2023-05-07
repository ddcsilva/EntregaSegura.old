namespace EntregaSegura.Shared.DTOs;

/// <summary>
/// Classe que representa um DTO (Data Transfer Object) para representar um registro de Unidade.
/// </summary>
public record UnidadeDTO(
    Guid Id, 
    string Numero, 
    string Bloco, 
    Guid CondominioId
);
