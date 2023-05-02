using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface IEntregaRepository
{
    IEnumerable<Entrega> ObterTodasEntregas(bool rastrearAlteracoes);
    Entrega? ObterEntregaPorId(Guid entregaId, bool rastrearAlteracoes);
}