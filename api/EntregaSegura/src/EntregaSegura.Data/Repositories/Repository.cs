using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Models;
using EntregaSegura.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EntregaSegura.Data.Repositories;

/// <summary>
/// Classe genérica de repositório.
/// </summary>
public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    protected readonly EntregaSeguraContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    /// <summary>
    /// Construtor Padrao, recebe o contexto do banco de dados e o DbSet da entidade.
    /// </summary>
    protected Repository(EntregaSeguraContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    /// <summary>
    /// Retorna uma lista de entidades.
    /// </summary>
    public virtual async Task<List<TEntity>> ObterTodos()
    {
        return await _dbSet.ToListAsync();
    }

    /// <summary>
    /// Retorna uma entidade pelo Id.
    /// </summary>
    /// <param name="id">Id da entidade a ser retornada.</param>
    public virtual async Task<TEntity> ObterPorId(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <summary>
    /// Adiciona uma entidade.
    /// </summary>
    /// <param name="entity">Entidade a ser adicionada.</param>
    public virtual async Task Adicionar(TEntity entity)
    {
        _dbSet.Add(entity);
        await SaveChanges();
    }

    /// <summary>
    /// Atualiza uma entidade.
    /// </summary>
    /// <param name="entity">Entidade a ser atualizada.</param>
    public virtual async Task Atualizar(TEntity entity)
    {
        _dbSet.Update(entity);
        await SaveChanges();
    }

    /// <summary>
    /// Remove uma entidade.
    /// </summary>
    /// <param name="id">Id da entidade a ser removida.</param>
    public virtual async Task Remover(Guid id)
    {
        _dbSet.Remove(new TEntity { Id = id });
        await SaveChanges();
    }

    /// <summary>
    /// Salva as alterações no banco de dados.
    /// </summary>
    /// <returns>Quantidade de linhas afetadas.</returns>
    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Libera os recursos utilizados.
    /// </summary>
    public void Dispose()
    {
        _context?.Dispose();
    }
}