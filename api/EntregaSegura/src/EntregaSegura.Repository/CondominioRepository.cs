using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public sealed class CondominioRepository : RepositoryBase<Condominio>, ICondominioRepository
{
    public CondominioRepository(EntregaSeguraContext entregaSeguraContexto) : base(entregaSeguraContexto) { }

    public IEnumerable<Condominio> ObterTodosCondominios(bool rastrearAlteracoes)
    {
        return BuscarTodos(rastrearAlteracoes).OrderBy(c => c.Nome).ToList();
    }
}