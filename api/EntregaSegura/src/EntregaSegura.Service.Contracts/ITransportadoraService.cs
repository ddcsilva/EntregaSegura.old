using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface ITransportadoraService
{
    IEnumerable<TransportadoraDTO> ObterTodasTransportadoras(bool rastrearAlteracoes);
    TransportadoraDTO ObterTransportadoraPorId(Guid transportadoraId, bool rastrearAlteracoes);
}