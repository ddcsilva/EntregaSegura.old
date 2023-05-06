using System.Linq.Expressions;
using EntregaSegura.Contracts;
using EntregaSegura.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EntregaSegura.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected EntregaSeguraContext _context { get; set; }

    public RepositoryBase(EntregaSeguraContext context)
    {
        _context = context;
    }

    public IQueryable<T> BuscarTodos(bool rastrearAlteracoes)
    {
        return !rastrearAlteracoes ?
            _context.Set<T>().AsNoTracking() :
            _context.Set<T>();
    }

    public IQueryable<T> BuscarPorCondicao(Expression<Func<T, bool>> expressao, bool rastrearAlteracoes)
    {
        return !rastrearAlteracoes ?
            _context.Set<T>().Where(expressao).AsNoTracking() :
            _context.Set<T>().Where(expressao);
    }

    public void Criar(T entidade)
    {
        _context.Set<T>().Add(entidade);
    }

    public void Atualizar(T entidade)
    {
        _context.Set<T>().Update(entidade);
    }

    public void Excluir(T entidade)
    {
        _context.Set<T>().Remove(entidade);
    }
}