namespace EntregaSegura.Entities.Models;

/// <summary>
/// Classe que representa um Morador
/// </summary>
public sealed class Morador : Usuario
{
    /// <summary>
    /// Construtor padrão que inicializa a propriedade Entregas.
    /// </summary>
    public Morador()
    {
        Entregas = new List<Entrega>();
    }
    
    public Guid UnidadeId { get; set; }

    // Um morador pertence a apenas uma unidade
    public Unidade? Unidade { get; set; }

    // Um morador pode receber várias entregas
    public IEnumerable<Entrega> Entregas { get; set; }
}