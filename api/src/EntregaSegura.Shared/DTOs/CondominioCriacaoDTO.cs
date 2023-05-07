namespace EntregaSegura.Shared.DTOs;

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