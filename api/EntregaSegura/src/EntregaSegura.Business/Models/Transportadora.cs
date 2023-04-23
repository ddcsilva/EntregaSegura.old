namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa uma transportadora.
/// </summary>
public sealed class Transportadora : Empresa
{
    /// <summary>
    /// Construtor padrão.
    /// </summary>
    public Transportadora()
    {
        
    }

    // Relacionamento 1:N (Uma transportadora possui várias entregas) e N:1 (Uma entrega pertence a uma transportadora)
    public IEnumerable<Entrega> Entregas { get; set; }
}