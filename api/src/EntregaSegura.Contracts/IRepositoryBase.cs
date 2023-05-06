using System.Linq.Expressions;

namespace EntregaSegura.Contracts;

public interface IRepositoryBase<T>
{
    IQueryable<T> BuscarTodos(bool rastrearAlteracoes);
    IQueryable<T> BuscarPorCondicao(Expression<Func<T, bool>> expressao, bool rastrearAlteracoes);
    void Criar(T entidade);
    void Atualizar(T entidade);
    void Excluir(T entidade);
}