namespace EntregaSegura.Shared.DTOs;

public record MoradorDTO(Guid Id, string Nome, string CPF, string Email, string Telefone, int Status, Guid UnidadeId);
