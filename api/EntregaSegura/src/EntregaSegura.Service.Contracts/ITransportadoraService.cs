using EntregaSegura.Entities.Models;

namespace EntregaSegura.Service.Contracts;

public interface ITransportadoraService
{
    IEnumerable<Transportadora> ObterTodasTransportadoras(bool rastrearAlteracoes);
}