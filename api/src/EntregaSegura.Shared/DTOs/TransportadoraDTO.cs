namespace EntregaSegura.Shared.DTOs;

/// <summary>
/// Classe que representa um DTO (Data Transfer Object) para representar um registro de Transportadora.
/// </summary>
public record TransportadoraDTO(
    Guid Id, 
    string Nome, 
    string CNPJ, 
    string Telefone, 
    string Email
);
