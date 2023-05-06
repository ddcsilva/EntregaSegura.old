using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public sealed class MoradorRepository : RepositoryBase<Morador>, IMoradorRepository
{
    public MoradorRepository(EntregaSeguraContext context) : base(context) { }

    public IEnumerable<Morador> ObterMoradores(bool rastrearAlteracoes)
    {
        return BuscarTodos(rastrearAlteracoes).OrderBy(c => c.Nome).ToList();
    }

    public Morador ObterMorador(Guid moradorId, bool rastrearAlteracoes)
    {
        return BuscarPorCondicao(c => c.Id == moradorId, rastrearAlteracoes).FirstOrDefault();
    }
}