using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public sealed class TransportadoraRepository : RepositoryBase<Transportadora>, ITransportadoraRepository
{
    public TransportadoraRepository(EntregaSeguraContext context) : base(context) { }

    public IEnumerable<Transportadora> ObterTransportadoras(bool rastrearAlteracoes)
    {
        return BuscarTodos(rastrearAlteracoes).OrderBy(c => c.Nome).ToList();
    }

    public Transportadora? ObterTransportadora(Guid transportadoraId, bool rastrearAlteracoes)
    {
        return BuscarPorCondicao(c => c.Id == transportadoraId, rastrearAlteracoes).FirstOrDefault();
    }
}