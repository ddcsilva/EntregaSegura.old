namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa um endereço.
/// </summary>
public sealed class Endereco : BaseEntity
{
    /// <summary>
    /// Construtor padrão que inicializa todas as propriedades, exceto as de relacionamento.
    /// </summary>
    public Endereco()
    {
        Logradouro = string.Empty;
        Numero = string.Empty;
        Complemento = string.Empty;
        CEP = string.Empty;
        Bairro = string.Empty;
        Cidade = string.Empty;
        Estado = string.Empty;
    }

    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string CEP { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }

    // Um endereço pertence a um condomínio
    public Guid CondominioId { get; set; }
    public Condominio Condominio { get; set; }
}