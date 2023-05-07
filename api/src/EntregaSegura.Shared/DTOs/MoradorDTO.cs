namespace EntregaSegura.Shared.DTOs;

/// <summary>
/// Classe que representa um DTO (Data Transfer Object) para representar um registro de Morador.
/// </summary>
public record MoradorDTO(
    Guid Id, 
    string Nome, 
    string CPF, 
    string Email, 
    string Telefone, 
    int Status, 
    Guid UnidadeId
);
