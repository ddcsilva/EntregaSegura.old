namespace EntregaSegura.Entities.Models;

/// <summary>
/// Classe que representa a base de todas as entidades do sistema.
/// </summary>
public abstract class BaseEntity : IEquatable<BaseEntity>
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.Now;
        DataAtualizacao = DateTime.Now;
    }

    public Guid Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime? DataExclusao { get; set; }

    public bool Equals(BaseEntity? outraEntidade)
    {
        if (outraEntidade == null)
            return false;

        if (ReferenceEquals(this, outraEntidade))
            return true;

        if (GetType() != outraEntidade.GetType())
            return false;

        return Id == outraEntidade.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}