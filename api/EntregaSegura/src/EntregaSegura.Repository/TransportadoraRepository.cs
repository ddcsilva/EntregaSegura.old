using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public sealed class TransportadoraRepository : RepositoryBase<Transportadora>, ITransportadoraRepository
{
    public TransportadoraRepository(EntregaSeguraContext context) : base(context) { }

    public IEnumerable<Transportadora> ObterTodasTransportadoras(bool rastrearAlteracoes)
    {
        return BuscarTodos(rastrearAlteracoes).OrderBy(c => c.Nome).ToList();
    }
}