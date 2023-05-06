using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface ITransportadoraRepository
{
    IEnumerable<Transportadora> ObterTransportadoras(bool rastrearAlteracoes);
    Transportadora? ObterTransportadora(Guid transportadoraId, bool rastrearAlteracoes);
}