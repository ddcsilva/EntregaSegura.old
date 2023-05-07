namespace EntregaSegura.Shared.DTOs;

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
