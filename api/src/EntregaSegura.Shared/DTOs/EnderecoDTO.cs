namespace EntregaSegura.Shared.DTOs;

public record EnderecoDTO(Guid Id, string Logradouro, string Numero, string Complemento, string CEP, string Bairro, string Cidade, string Estado, Guid CondominioId);
