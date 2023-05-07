namespace EntregaSegura.Shared.DTOs;

/// <summary>
/// Classe que representa um DTO (Data Transfer Object) para representar um registro de Condominio.
/// </summary>
public record CondominioDTO(
    Guid Id, 
    string Nome, 
    string CNPJ, 
    string Telefone, 
    string Email, 
    string Endereco, 
    string Cidade, 
    string Estado, 
    string CEP
);
