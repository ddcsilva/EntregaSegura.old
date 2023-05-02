using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface IUnidadeService
{
    IEnumerable<UnidadeDTO> ObterTodasUnidades(bool rastrearAlteracoes);
}