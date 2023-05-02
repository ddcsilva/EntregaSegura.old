using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface ITransportadoraRepository
{
    IEnumerable<Transportadora> ObterTodasTransportadoras(bool rastrearAlteracoes);
}