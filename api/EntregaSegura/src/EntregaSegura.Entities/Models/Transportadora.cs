namespace EntregaSegura.Entities.Models;

/// <summary>
/// Classe que representa uma transportadora.
/// </summary>
public sealed class Transportadora : Empresa
{
    /// <summary>
    /// Construtor padrão que inicializa a propriedade Entregas.
    /// </summary>
    public Transportadora()
    {
        Entregas = new List<Entrega>();
    }

    // Uma transportadora pode realizar várias entregas
    public ICollection<Entrega> Entregas { get; set; }
}