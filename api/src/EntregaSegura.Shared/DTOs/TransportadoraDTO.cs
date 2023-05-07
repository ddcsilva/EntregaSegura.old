namespace EntregaSegura.Shared.DTOs;

public record TransportadoraDTO(
    Guid Id, 
    string Nome, 
    string CNPJ, 
    string Telefone, 
    string Email
);
