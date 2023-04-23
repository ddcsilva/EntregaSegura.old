namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa uma unidade.
/// </summary>
public class Unidade : BaseEntity
{
    /// <summary>
    /// Construtor padrão.
    /// </summary>
    public Unidade()
    {
        Numero = string.Empty;
        Bloco = string.Empty;
    }

    public string Numero { get; set; }
    public string Bloco { get; set; }

    // Relacionamento 1:1 (Uma unidade pertence a um condomínio)
    public Guid CondominioId { get; set; }
    public Condominio Condominio { get; set; }

    // Relacionamento 1:N (Uma unidade possui várias entregas)
    public IEnumerable<Entrega> Entregas { get; set; }

    // Relacionamento 1:N (Uma unidade possui vários moradores)
    public IEnumerable<Morador> Moradores { get; set; } 
}