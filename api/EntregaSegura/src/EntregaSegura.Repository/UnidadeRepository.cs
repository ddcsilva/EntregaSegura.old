using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public class UnidadeRepository : RepositoryBase<Unidade>, IUnidadeRepository
{
    public UnidadeRepository(EntregaSeguraContext context) : base(context) { }

    public IEnumerable<Unidade> ObterTodasUnidades(bool rastrearAlteracoes)
    {
        return BuscarTodos(rastrearAlteracoes).OrderByDescending(c => c.Bloco).ToList();
    }

    public Unidade? ObterUnidadePorId(Guid unidadeId, bool rastrearAlteracoes)
    {
        return BuscarPorCondicao(c => c.Id == unidadeId, rastrearAlteracoes).FirstOrDefault();
    }
}