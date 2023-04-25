namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa a base de todas as entidades do sistema.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Construtor padrão que inicializa as propriedades.
    /// </summary>
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.Now;
    }

    public Guid Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataUltimaModificacao { get; set; }
    public bool Excluido { get; set; }
}