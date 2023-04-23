namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa uma transportadora.
/// </summary>
public sealed class Transportadora : BaseEntity
{
    /// <summary>
    /// Construtor padrão.
    /// </summary>
    public Transportadora()
    {
        Nome = string.Empty;
        Telefone = string.Empty;
        CNPJ = string.Empty;
    }

    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string CNPJ { get; set; }

    // Relacionamento 1:N (Uma transportadora possui várias entregas) e N:1 (Uma entrega pertence a uma transportadora)
    public IEnumerable<Entrega> Entregas { get; set; }
}