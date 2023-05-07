using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface ITransportadoraService
{
    IEnumerable<TransportadoraDTO> ObterTransportadoras(bool rastrearAlteracoes);
    TransportadoraDTO ObterTransportadora(Guid transportadoraId, bool rastrearAlteracoes);
    TransportadoraDTO CriarTransportadora(TransportadoraCriacaoDTO transportadora);
}