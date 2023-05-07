namespace EntregaSegura.Shared.DTOs;

/// <summary>
/// Classe que representa um DTO (Data Transfer Object) para representar um registro de Funcionario.
/// </summary>
public record FuncionarioDTO(
    Guid Id, 
    string Nome, 
    string CPF, 
    string Email, 
    string Telefone, 
    int Status, 
    int Cargo, 
    DateTime DataAdmissao, 
    DateTime? DataDemissao, 
    Guid CondominioId
);
