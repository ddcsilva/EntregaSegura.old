using System.Linq.Expressions;

namespace EntregaSegura.Contracts;

/// <summary>
/// Interface genérica que define os métodos base para interagir com qualquer tabela no banco de dados.
/// </summary>
public interface IRepositoryBase<T>
{
    IQueryable<T> BuscarTodos(bool rastrearAlteracoes);
    IQueryable<T> BuscarPorCondicao(Expression<Func<T, bool>> expressao, bool rastrearAlteracoes);
    void Criar(T entidade);
    void Atualizar(T entidade);
    void Excluir(T entidade);
}