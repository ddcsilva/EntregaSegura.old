using EntregaSegura.Business.Models;

namespace EntregaSegura.Business.Interfaces.Repositories;

/// <summary>
/// Interface que representa o repositório especializado de condomínio
/// </summary>
public interface ICondominioRepository : IRepository<Condominio>
{
    // Obtém um condomínio com o endereço
    Task<Condominio> ObterCondominioComEndereco(Guid id);

    // Obtém um condomínio com as unidades
    Task<Condominio> ObterCondominioComUnidades(Guid id);

    // Obtém todos os condomínios com o endereço
    Task<List<Condominio>> ObterTodosCondominioscomEndereco();

    // Obtém todos os condomínios com as unidades
    Task<List<Condominio>> ObterTodosCondominioscomUnidades();
}
