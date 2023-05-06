using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface ICondominioService
{
    IEnumerable<CondominioDTO> ObterCondominios(bool rastrearAlteracoes);
    CondominioDTO ObterCondominio(Guid condominioId, bool rastrearAlteracoes);
}