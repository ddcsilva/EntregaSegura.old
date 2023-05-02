using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public sealed class MoradorRepository : RepositoryBase<Morador>, IMoradorRepository
{
    public MoradorRepository(EntregaSeguraContext context) : base(context) { }

    public IEnumerable<Morador> ObterTodosMoradores(bool rastrearAlteracoes)
    {
        return BuscarTodos(rastrearAlteracoes).OrderBy(c => c.Nome).ToList();
    }
}