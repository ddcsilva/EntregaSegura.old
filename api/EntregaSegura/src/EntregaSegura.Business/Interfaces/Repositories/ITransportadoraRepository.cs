using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Models;

namespace EntregaSegura.Business.Interfaces;

public interface ITransportadoraRepository : IRepository<Transportadora>
{
    Task<IEnumerable<Transportadora>> ObterTransportadorasPorNome(string nome);
    Task<IEnumerable<Transportadora>> ObterTransportadorasPorCnpj(string cnpj);
}