using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface IEntregaRepository
{
    IEnumerable<Entrega> ObterEntregas(bool rastrearAlteracoes);
    Entrega? ObterEntrega(Guid entregaId, bool rastrearAlteracoes);
}