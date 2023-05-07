namespace EntregaSegura.Shared.DTOs;

/// <summary>
/// Classe que representa um DTO (Data Transfer Object) para criar um novo registro de Funcionario.
/// </summary>
public record FuncionarioCriacaoDTO(
    string Nome,
    string CPF,
    string Email,
    string Telefone,
    int? Status
);