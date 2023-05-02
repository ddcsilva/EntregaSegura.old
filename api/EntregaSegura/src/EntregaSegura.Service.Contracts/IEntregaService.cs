using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface IEntregaService
{
    IEnumerable<EntregaDTO> ObterTodasEntregas(bool rastrearAlteracoes);
    EntregaDTO ObterEntregaPorId(Guid entregaId, bool rastrearAlteracoes);
}