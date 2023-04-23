using EntregaSegura.Business.Models;

namespace EntregaSegura.Business.Interfaces.Repositories;

/// <summary>
/// Interface genérica de repositório.
/// </summary>
public interface IRepository<TEntity> where TEntity : BaseEntity
{
    // Retorna uma lista de entidades
    Task<List<TEntity>> ObterTodos();

    // Retorna uma entidade pelo Id
    Task<TEntity> ObterPorId(Guid id);

    // Adiciona uma entidade
    Task Adicionar(TEntity entity);

    // Atualiza uma entidade
    Task Atualizar(TEntity entity);

    // Remove uma entidade
    Task Remover(Guid id);
}