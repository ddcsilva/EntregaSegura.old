namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe base para as entidades do sistema.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Construtor padrão.
    /// </summary>
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.Now;
        Ativo = true;
    }

    public Guid Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataUltimaModificacao { get; set; }
    public bool Ativo { get; set; }
}