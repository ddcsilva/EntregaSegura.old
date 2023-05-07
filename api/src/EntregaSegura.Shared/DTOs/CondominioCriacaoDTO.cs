namespace EntregaSegura.Shared.DTOs;

/// <summary>
/// Classe que representa um DTO (Data Transfer Object) para criar um novo registro de Condominio.
/// </summary>
public record CondominioCriacaoDTO(
    string Nome, 
    string CNPJ, 
    string Telefone, 
    string Email, 
    string Logradouro, 
    string Numero,
    string? Complemento,
    string Bairro,
    string Cidade, 
    string Estado, 
    string CEP
);