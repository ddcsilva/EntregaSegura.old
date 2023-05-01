using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public class TransportadoraRepository : RepositoryBase<Transportadora>, ITransportadoraRepository
{
    public TransportadoraRepository(EntregaSeguraContext context) : base(context)
    {
    }
}