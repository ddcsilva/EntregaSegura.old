using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Models;

namespace EntregaSegura.Business.Interfaces;

/// <summary>
/// Interface que representa o repositório especializado de transportadora
/// </summary>
public interface ITransportadoraRepository : IRepository<Transportadora>
{
    // Obtém uma transportadora pelo Nome
    Task<IEnumerable<Transportadora>> ObterTransportadorasPorNome(string nome);

    // Obtém uma transportadora pelo CNPJ
    Task<IEnumerable<Transportadora>> ObterTransportadorasPorCnpj(string cnpj);
}