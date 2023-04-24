using System.Linq.Expressions;
using EntregaSegura.Business.Models;

namespace EntregaSegura.Business.Interfaces.Repositories;

/// <summary>
/// Interface que representa o repositório genérico
/// </summary>
public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
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

    // Retorna uma lista de entidades que atendem a um predicado
    Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

    // Retorna o número de entidades
    Task<int> SaveChanges();
}