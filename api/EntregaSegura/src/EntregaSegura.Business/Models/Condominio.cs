namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa um condomínio.
/// </summary>
public sealed class Condominio : BaseEntity
{
    /// <summary>
    /// Construtor padrão.
    /// </summary>
    public Condominio()
    {
        Nome = string.Empty;
        CNPJ = string.Empty;
        Telefone = string.Empty;
        Email = string.Empty;
    }

    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    // Relacionamento 1:1 (Um condomínio possui um endereço)
    public Endereco Endereco { get; set; }

    // Relacionamento 1:N (Um condomínio possui várias unidades)
    public IEnumerable<Unidade> Unidades { get; set; }
}