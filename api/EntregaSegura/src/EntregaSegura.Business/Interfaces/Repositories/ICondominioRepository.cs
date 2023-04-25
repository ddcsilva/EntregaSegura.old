using EntregaSegura.Business.Models;

namespace EntregaSegura.Business.Interfaces.Repositories;

/// <summary>
/// Interface que representa o repositório especializado de condomínio
/// </summary>
public interface ICondominioRepository : IRepository<Condominio>
{
    /// <summary>
    /// Obtém um condomínio com o endereço
    /// </summary>
    /// <param name="id">Identificador do condomínio</param>
    /// <returns>Condomínio com o endereço</returns>
    Task<Condominio> ObterCondominioComEndereco(Guid id);

    /// <summary>
    /// Obtém um condomínio com as unidades
    /// </summary>
    /// <param name="id">Identificador do condomínio</param>
    /// <returns>Condomínio com as unidades</returns>
    Task<Condominio> ObterCondominioComUnidades(Guid id);
}
