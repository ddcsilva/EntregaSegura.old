using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Models;

namespace EntregaSegura.Business.Interfaces;

/// <summary>
/// Interface que representa o repositório especializado de transportadora
/// </summary>
public interface ITransportadoraRepository : IRepository<Transportadora>
{
    /// <summary>
    /// Obtém uma transportadora pelo seu nome
    /// </summary>
    /// <param name="nome">Nome da transportadora</param>
    /// <returns>Retorna uma transportadora</returns>
    Task<IEnumerable<Transportadora>> ObterTransportadorasPorNome(string nome);

    /// <summary>
    /// Obtém uma transportadora pelo seu CNPJ
    /// </summary>
    /// <param name="cnpj">CNPJ da transportadora</param>
    /// <returns>Retorna uma transportadora</returns>
    Task<IEnumerable<Transportadora>> ObterTransportadorasPorCnpj(string cnpj);

    /// <summary>
    /// Obtém todas as transportadoras que realizaram entregas em uma unidade
    /// </summary>
    /// <param name="unidadeId">Id da unidade</param>
    /// <returns>Rertorna uma lista de transportadoras</returns>
    Task<IEnumerable<Transportadora>> ObterTodasTransportadorasQueRealizaramEntregasPorUnidade(int unidadeId);
}