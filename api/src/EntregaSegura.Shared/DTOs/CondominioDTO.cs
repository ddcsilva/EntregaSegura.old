namespace EntregaSegura.Shared.DTOs;

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
