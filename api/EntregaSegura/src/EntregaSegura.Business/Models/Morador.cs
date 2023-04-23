namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa um Morador
/// </summary>
public sealed class Morador : Usuario
{
    /// <summary>
    /// Construtor padrão.
    /// </summary>
    public Morador()
    {
        
    }

    // Relacionamento 1:1 (Um morador pertence a uma unidade)
    public Guid UnidadeId { get; set; }
    public Unidade Unidade { get; set; }

    // Relacionamento 1:N (Um morador pode ter várias entregas)
    public IEnumerable<Entrega> Entregas { get; set; }
}