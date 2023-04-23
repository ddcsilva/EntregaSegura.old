namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa um endereço.
/// </summary>
public class Endereco : BaseEntity
{
    /// <summary>
    /// Construtor padrão.
    /// </summary>
    public Endereco()
    {
        Logradouro = string.Empty;
        Numero = string.Empty;
        Complemento = string.Empty;
        Cep = string.Empty;
        Bairro = string.Empty;
        Cidade = string.Empty;
        Estado = string.Empty;
    }

    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Cep { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }

    // Relacionamento 1:1 (Um endereço pertence a um condomínio)
    public Guid CondominioId { get; set; }
    public Condominio Condominio { get; set; }
}