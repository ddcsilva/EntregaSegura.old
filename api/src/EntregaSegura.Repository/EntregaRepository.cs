using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public sealed class EntregaRepository : RepositoryBase<Entrega>, IEntregaRepository
{
    public EntregaRepository(EntregaSeguraContext context) : base(context) { }

    public IEnumerable<Entrega> ObterEntregas(bool rastrearAlteracoes)
    {
        return BuscarTodos(rastrearAlteracoes).OrderByDescending(c => c.DataRecebimento).ToList();
    }

    public Entrega ObterEntrega(Guid entregaId, bool rastrearAlteracoes)
    {
        return BuscarPorCondicao(c => c.Id == entregaId, rastrearAlteracoes).FirstOrDefault();
    }
}