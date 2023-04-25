using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Models;

namespace EntregaSegura.Business.Interfaces;

/// <summary>
/// Interface que representa o repositório especializado de unidade
/// </summary>
public interface IUnidadeRepository : IRepository<Unidade>
{
    /// <summary>
    /// Obtém todas unidades de um bloco
    /// </summary>
    /// <param name="bloco">Bloco</param>
    /// <returns>Retorna uma lista de unidades</returns>
    Task<IEnumerable<Unidade>> ObterUnidadesPorBloco(string bloco);

    /// <summary>
    /// Obtém todas unidades de um condomínio
    /// </summary>
    /// <param name="condominioId">Id do condomínio</param>
    /// <returns>Retorna uma lista de unidades</returns>
    Task<IEnumerable<Unidade>> ObterUnidadesPorCondominio(Guid condominioId);

    /// <summary>
    /// Obtém todas as unidades que possuem entregas pendentes
    /// </summary>
    /// <returns>Retorna uma lista de unidades</returns>
    Task<IEnumerable<Unidade>> ObterUnidadesComEntregasPendentes();
}