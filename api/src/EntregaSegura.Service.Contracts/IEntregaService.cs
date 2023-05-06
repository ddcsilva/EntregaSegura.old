using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface IEntregaService
{
    IEnumerable<EntregaDTO> ObterEntregas(bool rastrearAlteracoes);
    EntregaDTO ObterEntrega(Guid entregaId, bool rastrearAlteracoes);
}